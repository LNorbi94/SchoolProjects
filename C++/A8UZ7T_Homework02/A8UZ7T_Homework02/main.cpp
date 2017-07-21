#include <osg/MatrixTransform>
#include <osgDB/WriteFile>
#include <osgViewer/Viewer>

#ifdef _DEBUG
#pragma comment(lib, "osgd.lib")
#pragma comment(lib, "osgDBd.lib")
#pragma comment(lib, "osgViewerd.lib")
#else
#pragma comment(lib, "osg.lib")
#pragma comment(lib, "osgDB.lib")
#pragma comment(lib, "osgViewer.lib")
#endif

#pragma warning(disable : 4482 )

void calcSphere(float x, float y,
	osg::ref_ptr<osg::Vec3Array>& vertices,
	osg::ref_ptr<osg::Vec3Array>& normals,
	osg::ref_ptr<osg::Vec2Array>& texcoords,
	int r, int)
{
	float u = 2 * osg::PI * x;
	float v = osg::PI * y;
	vertices->push_back(osg::Vec3(r * sin(u) * sin(v), r * cos(v), r * cos(u) * sin(v)));
	normals->push_back(osg::Vec3(sin(u) * sin(v), cos(v), cos(u) * sin(v)));
	texcoords->push_back(osg::Vec2(x, y));
}
void calcCylinder(float y, float x,
	osg::ref_ptr<osg::Vec3Array>& vertices,
	osg::ref_ptr<osg::Vec3Array>& normals,
	osg::ref_ptr<osg::Vec2Array>& texcoords,
	int r, int h)
{
	float u = 2 * osg::PI * x;
	float v = osg::PI * y;
	vertices->push_back(osg::Vec3(r * cos(u), r * sin(u), h * v));
	normals->push_back(osg::Vec3(cos(u), sin(u), 0));
	texcoords->push_back(osg::Vec2(1, 1));
}

osg::ref_ptr<osg::Geode> generateParamSurface(int N, int M, int r, int h,
	void(*f)(float x, float y,
		osg::ref_ptr<osg::Vec3Array>& vertices,
		osg::ref_ptr<osg::Vec3Array>& normals,
		osg::ref_ptr<osg::Vec2Array>& texcoords, int, int))
{
	osg::ref_ptr<osg::Vec3Array> vertices = new osg::Vec3Array;
	osg::ref_ptr<osg::Vec3Array> normals = new osg::Vec3Array;
	osg::ref_ptr<osg::Vec2Array> texcoords = new osg::Vec2Array;

	float delta = 1.0 / N;
	float gamma = 1.0 / M;
	for (int i = 0; i < N; ++i)
	{
		for (int j = 0; j < M; ++j)
		{
			float x = i * delta;
			float y = j * gamma;
			f(x, y, vertices, normals, texcoords, r, h);
			f(x, y + gamma, vertices, normals, texcoords, r, h);
			f(x + delta, y, vertices, normals, texcoords, r, h);
			f(x + delta, y, vertices, normals, texcoords, r, h);
			f(x, y + gamma, vertices, normals, texcoords, r, h);
			f(x + delta, y + gamma, vertices, normals, texcoords, r, h);
		}
	}

	osg::ref_ptr<osg::Geometry> quad = new osg::Geometry;
	quad->setUseVertexBufferObjects(true);
	quad->setVertexArray(vertices.get());
	quad->setNormalArray(normals.get());
	quad->setNormalBinding(osg::Geometry::BIND_PER_VERTEX);
	quad->setTexCoordArray(0, texcoords.get());
	quad->addPrimitiveSet(new osg::DrawArrays(GL_TRIANGLES, 0, 6 * N * M));

	osg::ref_ptr<osg::Geode> root = new osg::Geode;
	root->addDrawable(quad.get());

	return root;
}

int main(int argc, char** argv)
{
	osg::ref_ptr<osg::Group> baseFinal = new osg::Group;
	osg::ref_ptr<osg::Group> base = new osg::Group;
	osg::ref_ptr<osg::Geode> head = generateParamSurface(16, 16, 3, 0, calcSphere);
	osg::ref_ptr<osg::Geode> body = generateParamSurface(16, 16, 2, 3, calcCylinder);

	osg::ref_ptr<osg::Group> gHead = new osg::Group;
	osg::ref_ptr<osg::MatrixTransform> headTr = new osg::MatrixTransform();
	headTr->setMatrix(osg::Matrix::scale(1.25, 1.25, 1.25) * osg::Matrix::translate(0, 0, 8));
	headTr->addChild(head.get());
	gHead->addChild(headTr);

	osg::ref_ptr<osg::MatrixTransform> bTrans = new osg::MatrixTransform();
	bTrans->setMatrix(osg::Matrix::rotate(-osg::PI / 2.0, 0, 1, 0));
	
	base->addChild(gHead);
	base->addChild(body);
	bTrans->addChild(base.get());
	baseFinal->addChild(bTrans);
	osgDB::writeNodeFile(*baseFinal.get(), "a.obj");

	osg::ref_ptr<osg::Group> biggerTree = new osg::Group;
	osg::ref_ptr<osg::MatrixTransform> treeTr = new osg::MatrixTransform();
	treeTr->setMatrix(osg::Matrix::scale(1.5, 1.5, 1.5));
	treeTr->addChild(base.get());
	biggerTree->addChild(treeTr);

	osg::ref_ptr<osg::Group> biggerTrees = new osg::Group;
	for (int i = 0; i < 11; ++i)
	{
		osg::ref_ptr<osg::MatrixTransform> trans = new osg::MatrixTransform();
		trans->setMatrix(osg::Matrix::translate(osg::Vec3(cos(osg::PI * 2 / 11.0 * i) * 15, sin(osg::PI * 2 / 11.0 * i) * 15, 0.0f))
			* osg::Matrix::scale(1.0f * ((100.0f - 5.0f * i) / 100.0f), 1.0f * ((100.0f - 5.0f * i) / 100.0f), 1.0f * ((100.0f - 5.0f * i) / 100.0f)));
		trans->addChild(biggerTree.get());
		biggerTrees->addChild(trans);
	}
	osg::ref_ptr<osg::Group> forest = new osg::Group;
	osg::ref_ptr<osg::MatrixTransform> tTrans = new osg::MatrixTransform();
	tTrans->setMatrix(osg::Matrix::rotate(-osg::PI / 2.0, 0, 1, 0));

	tTrans->addChild(biggerTrees.get());
	forest->addChild(tTrans);
	osgDB::writeNodeFile(*forest.get(), "b.obj");

	
		osg::StateSet* state = forest->getOrCreateStateSet();
	state->setMode(GL_CULL_FACE, osg::StateAttribute::ON);

	osgViewer::Viewer viewer;
	viewer.setSceneData(forest.get());
	
	/*
	osg::StateSet* state = biggerTree->getOrCreateStateSet();
	state->setMode(GL_CULL_FACE, osg::StateAttribute::ON);

	osgViewer::Viewer viewer;
	viewer.setSceneData(biggerTree.get());
	*/
	viewer.setUpViewInWindow(20, 20, 640, 480);
	viewer.realize();
	return viewer.run();
}