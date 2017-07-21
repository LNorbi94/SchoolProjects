#include <osg/Texture2D>
#include <osg/Geometry>
#include <osg/MatrixTransform>
#include <osgDB/ReadFile>
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

void calcGomb(float x, float y,
	osg::ref_ptr<osg::Vec3Array>& vertices,
	osg::ref_ptr<osg::Vec3Array>& normals,
	osg::ref_ptr<osg::Vec2Array>& texcoords
	)
{
	float u = 2 * osg::PI * x;
	float v = osg::PI * y;
	vertices->push_back(osg::Vec3(sin(u)*sin(v), cos(v), cos(u)*sin(v)));
	normals->push_back(osg::Vec3(sin(u)*sin(v), cos(v), cos(u)*sin(v)));
	texcoords->push_back(osg::Vec2(x, y));
}
void calcHenger(float y, float x, osg::ref_ptr<osg::Vec3Array>& vertices, osg::ref_ptr<osg::Vec3Array>& normals, osg::ref_ptr<osg::Vec2Array>& texcoords)
{
	float u = 2 * osg::PI * x;
	float v = y * 4;
	vertices->push_back(osg::Vec3(cos(u)*0.25, sin(u)*0.25, v));
	osg::Vec3 du = osg::Vec3(-sin(u), cos(u), 0);
	osg::Vec3 dv = osg::Vec3(0, 0, 1);
	osg::Vec3 n = du ^ dv;
	n.normalize();
	normals->push_back(n);
	texcoords->push_back(osg::Vec2(y, x));
}

osg::ref_ptr<osg::Geode> generateParamSurface(int N, int M,
	void(*f)(float x, float y,
		osg::ref_ptr<osg::Vec3Array>& vertices,
		osg::ref_ptr<osg::Vec3Array>& normals,
		osg::ref_ptr<osg::Vec2Array>& texcoords))
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
			f(x, y, vertices, normals, texcoords);
			f(x, y + gamma, vertices, normals, texcoords);
			f(x + delta, y, vertices, normals, texcoords);
			f(x + delta, y, vertices, normals, texcoords);
			f(x, y + gamma, vertices, normals, texcoords);
			f(x + delta, y + gamma, vertices, normals, texcoords);
		}
	}

	osg::ref_ptr<osg::Geometry> quad = new osg::Geometry;
	quad->setUseVertexBufferObjects(true);
	quad->setVertexArray(vertices.get());
	quad->setNormalArray(normals.get());
	quad->setNormalBinding(osg::Geometry::BIND_PER_VERTEX);
	quad->setTexCoordArray(0, texcoords.get());
	quad->addPrimitiveSet(new osg::DrawArrays(GL_TRIANGLE_STRIP, 0, 6 * N * M));

	osg::ref_ptr<osg::Geode> root = new osg::Geode;
	root->addDrawable(quad.get());
	return root;
}

int main(int argc, char** argv)
{
	osg::ref_ptr<osg::Group> root = new osg::Group;
	osg::ref_ptr<osg::Geode> fej = generateParamSurface(6, 3, calcGomb);
	osg::ref_ptr<osg::Geode> henger = generateParamSurface(10, 10, calcHenger);

	osg::ref_ptr<osg::Group> gfej = new osg::Group;
	osg::ref_ptr<osg::MatrixTransform> fejTr = new osg::MatrixTransform();
	fejTr->setMatrix(osg::Matrix::scale(1, 1, 1.5) * osg::Matrix::translate(0, 0, 4.5));
	fejTr->addChild(fej.get());
	gfej->addChild(fejTr);

	osg::ref_ptr<osg::Group> gNyak = new osg::Group;
	gNyak->addChild(henger);

	root->addChild(gfej);

	for (int i = 0; i < 6; ++i)
	{
		osg::ref_ptr<osg::MatrixTransform> lab1Tr = new osg::MatrixTransform();
		lab1Tr->setMatrix(osg::Matrix::scale(0.2, 0.2, 0.5) * osg::Matrix::rotate(osg::PI / 4.0f, osg::Y_AXIS)
			* osg::Matrix::rotate(osg::PI * 2 / 6.0 * i, osg::Z_AXIS));
		lab1Tr->addChild(henger);

		osg::ref_ptr<osg::MatrixTransform> lab2Tr = new osg::MatrixTransform();
		lab2Tr->setMatrix(osg::Matrix::scale(0.2, 0.2, 0.5) * osg::Matrix::rotate(-osg::PI / 4.0f, osg::Y_AXIS) * osg::Matrix::translate(sqrt(2) * 2, 0, 0)
			* osg::Matrix::rotate(osg::PI * 2 / 6.0 * i, osg::Z_AXIS));
		lab2Tr->addChild(henger);

		gNyak->addChild(lab1Tr);
		gNyak->addChild(lab2Tr);
	}

	osg::ref_ptr<osg::MatrixTransform> exportTr = new osg::MatrixTransform();
	exportTr->setMatrix(osg::Matrix::rotate(-osg::PI / 2.0f, osg::X_AXIS));
	exportTr->addChild(gNyak);
	osgDB::writeNodeFile(*exportTr, "labak.obj");


	osg::ref_ptr<osg::MatrixTransform> exportTr2 = new osg::MatrixTransform();
	exportTr2->setMatrix(osg::Matrix::rotate(-osg::PI / 2.0f, osg::X_AXIS));
	exportTr2->addChild(gfej);
	osgDB::writeNodeFile(*exportTr2, "fej.obj");

	osg::ref_ptr<osg::Texture2D> texture1 = new osg::Texture2D;
	osg::ref_ptr<osg::Image> image = osgDB::readImageFile("fej.jpg");
	texture1->setImage(image.get());
	texture1->setFilter(osg::Texture::FilterParameter::MIN_FILTER, osg::Texture::FilterMode::LINEAR_MIPMAP_LINEAR);
	texture1->setFilter(osg::Texture::FilterParameter::MAG_FILTER, osg::Texture::FilterMode::LINEAR);
	texture1->setWrap(osg::Texture::WRAP_S, osg::Texture::WrapMode::REPEAT);
	texture1->setWrap(osg::Texture::WRAP_T, osg::Texture::WrapMode::REPEAT);

	osg::ref_ptr<osg::Texture2D> texture2 = new osg::Texture2D;
	osg::ref_ptr<osg::Image> image2 = osgDB::readImageFile("labak.jpg");
	texture2->setImage(image2.get());
	texture2->setFilter(osg::Texture::FilterParameter::MIN_FILTER, osg::Texture::FilterMode::LINEAR_MIPMAP_LINEAR);
	texture2->setFilter(osg::Texture::FilterParameter::MAG_FILTER, osg::Texture::FilterMode::LINEAR);
	texture2->setWrap(osg::Texture::WRAP_S, osg::Texture::WrapMode::REPEAT);
	texture2->setWrap(osg::Texture::WRAP_T, osg::Texture::WrapMode::REPEAT);

	gNyak->getOrCreateStateSet()->setTextureAttributeAndModes(0, texture2.get());
	gfej->getOrCreateStateSet()->setTextureAttributeAndModes(0, texture1.get());

	root->addChild(gNyak);

	root->getOrCreateStateSet()->setMode(GL_CULL_FACE, osg::StateAttribute::ON);

	osgViewer::Viewer viewer;
	viewer.setSceneData(root.get());

	viewer.setUpViewInWindow(20, 20, 640, 480);
	viewer.realize();

	return viewer.run();
}