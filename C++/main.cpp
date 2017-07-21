#include <osg/Texture2D>
#include <osg/Geometry>
#include <osg/MatrixTransform>
#include <osgDB/ReadFile>
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
	normals->push_back(osg::Vec3(cos(u), sin(u), 0));
	texcoords->push_back(osg::Vec2(1, 1));
}

osg::ref_ptr<osg::Geode> generateParamSurface(int N, int M, 
	void(*f)(	float x, float y,
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
	// textúra betöltése
	osg::ref_ptr<osg::Texture2D> texture = new osg::Texture2D;
	osg::ref_ptr<osg::Image> image = osgDB::readImageFile("Images/land_shallow_topo_2048.jpg");
	texture->setImage(image.get());
	texture->setFilter(osg::Texture::FilterParameter::MIN_FILTER, osg::Texture::FilterMode::LINEAR_MIPMAP_LINEAR);
	texture->setFilter(osg::Texture::FilterParameter::MAG_FILTER, osg::Texture::FilterMode::LINEAR);
	texture->setWrap(osg::Texture::WRAP_S, osg::Texture::WrapMode::REPEAT);
	texture->setWrap(osg::Texture::WRAP_T, osg::Texture::WrapMode::REPEAT);

	root->addChild(gfej);
	root->addChild(henger);
	// rakjuk be egy geode-ba a quad-ot, mint kirajzolandó elemet!
	//osg::ref_ptr<osg::Geode> root = new osg::Geode;
	//root->addDrawable(fej.get());

	// 0-ás mintavételezõre rakjuk rá a textúrát
	//root->getOrCreateStateSet()->setTextureAttributeAndModes(0, texture.get());
	//osg::StateSet* state = root->getOrCreateStateSet();
	

	// hozzuk létre a viewer-t és állítsuk be a gyökeret megjelenítendõ adatnak
	osgViewer::Viewer viewer;
	viewer.setSceneData(root.get());

	// a (20,20) kezdeti pozícióba hozzunk létre egy 640x480-as ablakot
	viewer.setUpViewInWindow(20, 20, 640, 480);
	viewer.realize();

	// adjuk át a vezérlést a viewer-nek
	return viewer.run();
}