#include <osg/Texture2D>
#include <osg/Geometry>
#include <osgDB/ReadFile>
#include <osgViewer/Viewer>
#include <osg/PolygonMode>
#include <osg/MatrixTransform>

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

int main(int argc, char** argv)
{
	// pozíciók
	osg::ref_ptr<osg::Vec3Array> vertices = new osg::Vec3Array;

	// a piramis öt csúcspontja
	osg::Vec3 pa(-1.0f, 0.0f, -1.0f); osg::Vec3 ca(1.0f, 0.0f, 0.0f);
	osg::Vec3 pb(1.0f, 0.0f, -1.0f); osg::Vec3 cb(0.0f, 1.0f, 0.0f);
	osg::Vec3 pc(-1.0f, 0.0f, 1.0f); osg::Vec3 cc(0.0f, 0.0f, 1.0f);
	osg::Vec3 pd(1.0f, 0.0f, 1.0f); osg::Vec3 cd(1.0f, 1.0f, 0.0f);
	osg::Vec3 pe(0.0f, 1.0f, 0.0f); osg::Vec3 ce(1.0f, 0.0f, 1.0f);

	// alaplap - 1. háromszög
	vertices->push_back(pa);
	vertices->push_back(pb);
	vertices->push_back(pc);
	// alaplap - 2. háromszög
	vertices->push_back(pc);
	vertices->push_back(pb);
	vertices->push_back(pd);
	// 1. oldallap
	vertices->push_back(pe);
	vertices->push_back(pb);
	vertices->push_back(pa);
	// 2. oldallap
	vertices->push_back(pe);
	vertices->push_back(pa);
	vertices->push_back(pc);
	// 3. oldallap
	vertices->push_back(pe);
	vertices->push_back(pc);
	vertices->push_back(pd);
	// 3. oldallap
	vertices->push_back(pe);
	vertices->push_back(pd);
	vertices->push_back(pb);

	// normálisok
	osg::ref_ptr<osg::Vec3Array> normals = new osg::Vec3Array;
	// alaplap - 1. háromszög normálisai
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	// alaplap - 2. háromszög normálisai
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	// normálisok
	float sqo2 = sqrtf(2) / 2;

	// 1. oldallap normálisai
	osg::Vec3 nf1 = { 0, sqo2, -sqo2 };
	normals->push_back(nf1);
	normals->push_back(nf1);
	normals->push_back(nf1);
	// 2. oldallap normálisai
	osg::Vec3 nf2 = { -sqo2, sqo2, 0 };
	normals->push_back(nf2);
	normals->push_back(nf2);
	normals->push_back(nf2);
	// 3. oldallap normálisai
	osg::Vec3 nf3 = { 0, sqo2, sqo2 };
	normals->push_back(nf3);
	normals->push_back(nf3);
	normals->push_back(nf3);
	// 4. oldallap normálisai
	osg::Vec3 nf4 = { sqo2, sqo2, 0 };
	normals->push_back(nf4);
	normals->push_back(nf4);
	normals->push_back(nf4);

	// színek
	osg::ref_ptr<osg::Vec3Array> colarray = new osg::Vec3Array;
	// alaplap - 1. háromszög színei
	colarray->push_back(ca);
	colarray->push_back(cb);
	colarray->push_back(cc);
	// alaplap - 2. háromszög színei
	colarray->push_back(cc);
	colarray->push_back(cb);
	colarray->push_back(cd);
	// 1. oldallap színei
	colarray->push_back(ce);
	colarray->push_back(ca);
	colarray->push_back(cb);
	// 2. oldallap színei
	colarray->push_back(ca);
	colarray->push_back(ca);
	colarray->push_back(ca);
	// 3. oldallap színei
	colarray->push_back(cb);
	colarray->push_back(cb);
	colarray->push_back(cb);
	// 4. oldallap színei
	colarray->push_back(cd);
	colarray->push_back(cd);
	colarray->push_back(cd);


	// geometria
	osg::ref_ptr<osg::Geometry> quad = new osg::Geometry;
	// azt akarjuk, h VBO-ban tárolja az OSG a geometriánkat, ehhez
	// ki kell kapcsolni a display list-es (elavult OGL-es) támogatást ( setUseDisplayList(false) )
	// és külön meg kell kérni a VBO használatot ( setUseVertexBufferObjects(true) )
	quad->setUseDisplayList(false);
	quad->setUseVertexBufferObjects(true);
	// és most határozzuk meg, hogy a pozíció, normális és színadatok honnan jöjjenek:

	// a pozíció adatok a vertices tömbbõl
	quad->setVertexArray(vertices.get());

	// a normálisok a normals tömbbõl
	quad->setNormalArray(normals.get());
	// úgy, hogy a normals tömb minden egyes csúcsponthoz külön tárolja a normálisokat
	quad->setNormalBinding(osg::Geometry::BIND_PER_VERTEX);
	// a színek pedig a colarray tömbbõl jöjjenek, szintén csúcspontonként definiálva
	quad->setColorArray(colarray.get());
	quad->setColorBinding(osg::Geometry::BIND_PER_VERTEX);

	// kirajzolandó primitív meghatározása
	quad->addPrimitiveSet(new osg::DrawArrays(GL_TRIANGLES, 0, 18));
	// rakjuk be egy geode-ba a piramist, mint kirajzolandó elemet!
	osg::ref_ptr<osg::Geode> piramis = new osg::Geode;
	piramis->addDrawable(quad.get());

	// a hátrafelé nézõ lapokat rajzoljuk ki vonalasan csak
	osg::ref_ptr<osg::PolygonMode> pm = new osg::PolygonMode;
	pm->setMode(osg::PolygonMode::BACK,
		osg::PolygonMode::LINE);
	piramis->getOrCreateStateSet()->setAttribute(pm.get());

	// szintergraf:
	osg::ref_ptr<osg::Group> root = new osg::Group;
	osg::ref_ptr<osg::MatrixTransform> trafo1 = new osg::MatrixTransform;
	osg::ref_ptr<osg::MatrixTransform> trafo2 = new osg::MatrixTransform;

	root->addChild(trafo1.get());
	root->addChild(trafo2.get());

	trafo1->addChild(piramis.get());
	trafo2->addChild(piramis.get());

	trafo1->setMatrix(osg::Matrix::identity());
	trafo2->setMatrix(osg::Matrix::rotate(osg::PI, 1, 0, 0));

	// 1. feladat: építsd fel teljesen a piramist!
	// 2. feladat: textúrázd fel a piramist!
	// 3. feladat: készíts egy síklapot homok textúrával és helyezd a piramis alá!

	// hozzuk létre a viewer-t és állítsuk be a gyökeret megjelenítendõ adatnak
	osgViewer::Viewer viewer;
	viewer.setSceneData(root.get());

	// a (20,20) kezdeti pozícióba hozzunk létre egy 640x480-as ablakot
	viewer.setUpViewInWindow(30, 30, 640, 480);
	viewer.realize();

	// adjuk át a vezérlést a viewer-nek
	return viewer.run();
}