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
	// poz�ci�k
	osg::ref_ptr<osg::Vec3Array> vertices = new osg::Vec3Array;

	// a piramis �t cs�cspontja
	osg::Vec3 pa(-1.0f, 0.0f, -1.0f); osg::Vec3 ca(1.0f, 0.0f, 0.0f);
	osg::Vec3 pb(1.0f, 0.0f, -1.0f); osg::Vec3 cb(0.0f, 1.0f, 0.0f);
	osg::Vec3 pc(-1.0f, 0.0f, 1.0f); osg::Vec3 cc(0.0f, 0.0f, 1.0f);
	osg::Vec3 pd(1.0f, 0.0f, 1.0f); osg::Vec3 cd(1.0f, 1.0f, 0.0f);
	osg::Vec3 pe(0.0f, 1.0f, 0.0f); osg::Vec3 ce(1.0f, 0.0f, 1.0f);

	// alaplap - 1. h�romsz�g
	vertices->push_back(pa);
	vertices->push_back(pb);
	vertices->push_back(pc);
	// alaplap - 2. h�romsz�g
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

	// norm�lisok
	osg::ref_ptr<osg::Vec3Array> normals = new osg::Vec3Array;
	// alaplap - 1. h�romsz�g norm�lisai
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	// alaplap - 2. h�romsz�g norm�lisai
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	normals->push_back(osg::Vec3(0.0f, -1.0f, 0.0f));
	// norm�lisok
	float sqo2 = sqrtf(2) / 2;

	// 1. oldallap norm�lisai
	osg::Vec3 nf1 = { 0, sqo2, -sqo2 };
	normals->push_back(nf1);
	normals->push_back(nf1);
	normals->push_back(nf1);
	// 2. oldallap norm�lisai
	osg::Vec3 nf2 = { -sqo2, sqo2, 0 };
	normals->push_back(nf2);
	normals->push_back(nf2);
	normals->push_back(nf2);
	// 3. oldallap norm�lisai
	osg::Vec3 nf3 = { 0, sqo2, sqo2 };
	normals->push_back(nf3);
	normals->push_back(nf3);
	normals->push_back(nf3);
	// 4. oldallap norm�lisai
	osg::Vec3 nf4 = { sqo2, sqo2, 0 };
	normals->push_back(nf4);
	normals->push_back(nf4);
	normals->push_back(nf4);

	// sz�nek
	osg::ref_ptr<osg::Vec3Array> colarray = new osg::Vec3Array;
	// alaplap - 1. h�romsz�g sz�nei
	colarray->push_back(ca);
	colarray->push_back(cb);
	colarray->push_back(cc);
	// alaplap - 2. h�romsz�g sz�nei
	colarray->push_back(cc);
	colarray->push_back(cb);
	colarray->push_back(cd);
	// 1. oldallap sz�nei
	colarray->push_back(ce);
	colarray->push_back(ca);
	colarray->push_back(cb);
	// 2. oldallap sz�nei
	colarray->push_back(ca);
	colarray->push_back(ca);
	colarray->push_back(ca);
	// 3. oldallap sz�nei
	colarray->push_back(cb);
	colarray->push_back(cb);
	colarray->push_back(cb);
	// 4. oldallap sz�nei
	colarray->push_back(cd);
	colarray->push_back(cd);
	colarray->push_back(cd);


	// geometria
	osg::ref_ptr<osg::Geometry> quad = new osg::Geometry;
	// azt akarjuk, h VBO-ban t�rolja az OSG a geometri�nkat, ehhez
	// ki kell kapcsolni a display list-es (elavult OGL-es) t�mogat�st ( setUseDisplayList(false) )
	// �s k�l�n meg kell k�rni a VBO haszn�latot ( setUseVertexBufferObjects(true) )
	quad->setUseDisplayList(false);
	quad->setUseVertexBufferObjects(true);
	// �s most hat�rozzuk meg, hogy a poz�ci�, norm�lis �s sz�nadatok honnan j�jjenek:

	// a poz�ci� adatok a vertices t�mbb�l
	quad->setVertexArray(vertices.get());

	// a norm�lisok a normals t�mbb�l
	quad->setNormalArray(normals.get());
	// �gy, hogy a normals t�mb minden egyes cs�csponthoz k�l�n t�rolja a norm�lisokat
	quad->setNormalBinding(osg::Geometry::BIND_PER_VERTEX);
	// a sz�nek pedig a colarray t�mbb�l j�jjenek, szint�n cs�cspontonk�nt defini�lva
	quad->setColorArray(colarray.get());
	quad->setColorBinding(osg::Geometry::BIND_PER_VERTEX);

	// kirajzoland� primit�v meghat�roz�sa
	quad->addPrimitiveSet(new osg::DrawArrays(GL_TRIANGLES, 0, 18));
	// rakjuk be egy geode-ba a piramist, mint kirajzoland� elemet!
	osg::ref_ptr<osg::Geode> piramis = new osg::Geode;
	piramis->addDrawable(quad.get());

	// a h�trafel� n�z� lapokat rajzoljuk ki vonalasan csak
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

	// 1. feladat: �p�tsd fel teljesen a piramist!
	// 2. feladat: text�r�zd fel a piramist!
	// 3. feladat: k�sz�ts egy s�klapot homok text�r�val �s helyezd a piramis al�!

	// hozzuk l�tre a viewer-t �s �ll�tsuk be a gy�keret megjelen�tend� adatnak
	osgViewer::Viewer viewer;
	viewer.setSceneData(root.get());

	// a (20,20) kezdeti poz�ci�ba hozzunk l�tre egy 640x480-as ablakot
	viewer.setUpViewInWindow(30, 30, 640, 480);
	viewer.realize();

	// adjuk �t a vez�rl�st a viewer-nek
	return viewer.run();
}