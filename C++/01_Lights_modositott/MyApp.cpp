#include "MyApp.h"
#include "GLUtils.hpp"

#include <GL/GLU.h>
#include <math.h>

CMyApp::CMyApp(void)
{
	m_vaoID = 0;
	m_vboID = 0;
	m_programID = 0;
	m_textureID = 0;
}


CMyApp::~CMyApp(void)
{
}


GLuint CMyApp::GenTexture()
{
    unsigned char tex[256][256][3];
 
    for (int i=0; i<256; ++i)
        for (int j=0; j<256; ++j)
        {
			tex[i][j][0] = rand()%256;
			tex[i][j][1] = rand()%256;
			tex[i][j][2] = rand()%256;
        }
 
	GLuint tmpID;

	// generate a texture resource name
    glGenTextures(1, &tmpID);
	// activate it
    glBindTexture(GL_TEXTURE_2D, tmpID);
	// load data into GPU memory
    gluBuild2DMipmaps(  GL_TEXTURE_2D,	// into the active texture
						GL_RGB8,		// 8 bits for the red, green, and blue channels each
						256, 256,		// texture size is 256x256 pixels
						GL_RGB,				// the texture source (=system memory array tex) layout is (red, green, blue)
						GL_UNSIGNED_BYTE,	// each component is stored on 8 bits (a char)
						tex);				// the source of the texture
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);	// bilinear filter on min
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);	// bilinear filter on max
	glBindTexture(GL_TEXTURE_2D, 0); // deactivate the texture

	return tmpID;
}

bool CMyApp::Init()
{
	// clear color set to blue-ish
	glClearColor(0.125f, 0.25f, 0.5f, 1.0f);

	glEnable(GL_CULL_FACE);		// turn on back-face culling
	glEnable(GL_DEPTH_TEST);	// enable depth-test

	//
	// define the geometry
	//

	glm::vec3 piramis[5] = {
		glm::vec3(-5, 0, 5),	//0
		glm::vec3(5, 0, 5),	//1
		glm::vec3(5, 0, -5),	//2
		glm::vec3(-5, 0, -5),	//3
		glm::vec3(0, 10, 0) //4
	};

	glm::vec3 zero	{ 1, 0, 0 };
	glm::vec3 one	{ 1, 0, 0 };
	glm::vec3 fourth { 1, 1, 0 };

	Vertex vert[] =
	{ 
		{ piramis[0], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[1], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[4], glm::cross(one - zero, fourth - zero), glm::vec2(1, 1) },

		{ piramis[1], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[2], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[4], glm::cross(one - zero, fourth - zero), glm::vec2(1, 1) },

		{ piramis[2], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[3], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[4], glm::cross(one - zero, fourth - zero), glm::vec2(1, 1) },

		{ piramis[3], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[0], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[4], glm::cross(one - zero, fourth - zero), glm::vec2(1, 1) },

		{ piramis[3], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[2], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[0], glm::cross(one - zero, fourth - zero), glm::vec2(1, 1) },

		{ piramis[2], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[1], glm::cross(one - zero, fourth - zero), glm::vec2(1, 0) },
		{ piramis[0], glm::cross(one - zero, fourth - zero), glm::vec2(1, 1) },

	};

	// create index buffer
    GLushort indices[]=
    {
        1,0,2,
        1,2,3,
    };

	// create a VAO
	glGenVertexArrays(1, &m_vaoID);
	// activate the new VAO m_vaoID
	glBindVertexArray(m_vaoID);
	
	// create a VBO
	glGenBuffers(1, &m_vboID); 
	glBindBuffer(GL_ARRAY_BUFFER, m_vboID); // activate the VBO m_vboID
	// load the data stored in array vert into the VBO (essentially: upload the data to the GPU)
	glBufferData( GL_ARRAY_BUFFER,	// allocate memory for the active VBO and set its data
				  sizeof(vert),		// size of the VBO allocation, in bytes
				  vert,				// load data into the VBO from this location of the system memory
				  GL_STATIC_DRAW);	// we only want to store data into the VBO once (STATIC), and we want to use the VBO as a source for drawing our scene at each frame (DRAW)
									// for other usage flags see http://www.opengl.org/sdk/docs/man/xhtml/glBufferData.xml
									// {STREAM, STATIC, DYNAMIC} and {DRAW, READ, COPY}
	

	// activate the first general attribute 'channel' in the VAO
	glEnableVertexAttribArray(0); 
	glVertexAttribPointer(
		0,				// set the attributes of VAO channel 0
		3,				// this channel has 3 componenets
		GL_FLOAT,		// each of those componenets are floats
		GL_FALSE,		// do not normalize
		sizeof(Vertex),	// stride
		0				// channel 0`s data begins at the beginning of the VBO, no offset
	); 

	// activate 'channel' idx 1
	glEnableVertexAttribArray(1); 
	glVertexAttribPointer(
		1,
		3, 
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(sizeof(glm::vec3)) );

	// texture coordinates
	glEnableVertexAttribArray(2); 
	glVertexAttribPointer(
		2,
		2, 
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(2*sizeof(glm::vec3)) );

	// create index buffer
	glGenBuffers(1, &m_ibID);
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, m_ibID);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

	glBindVertexArray(0); 
	glBindBuffer(GL_ARRAY_BUFFER, 0); 
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0); 

	//
	// shader initialization
	//
	GLuint vs_ID = loadShader(GL_VERTEX_SHADER,		"myVert.vert");
	GLuint fs_ID = loadShader(GL_FRAGMENT_SHADER,	"myFrag.frag");

	// create the shader container (program)
	m_programID = glCreateProgram();

	// attach the vertex and fragment (pixel) shaders to the program
	glAttachShader(m_programID, vs_ID);
	glAttachShader(m_programID, fs_ID);

	// make correspondances between the VAO channels and the shader 'in' variables
	// IMPORTANT: do this prior to linking the programs!
	glBindAttribLocation(	m_programID,	// ID of the shader program from which we want to map a variable to a channel
							0,				// the VAO channel number we want to bind the variable to
							"vs_in_pos");	// the name of the variable in the shader
	glBindAttribLocation( m_programID, 1, "vs_in_normal");
	glBindAttribLocation( m_programID, 2, "vs_in_tex0");

	// link the shaders
	glLinkProgram(m_programID);

	// check the linking
	GLint infoLogLength = 0, result = 0;

	glGetProgramiv(m_programID, GL_LINK_STATUS, &result);
	glGetProgramiv(m_programID, GL_INFO_LOG_LENGTH, &infoLogLength);
	if ( GL_FALSE == result )
	{
		std::vector<char> ProgramErrorMessage( infoLogLength );
		glGetProgramInfoLog(m_programID, infoLogLength, NULL, &ProgramErrorMessage[0]);
		fprintf(stdout, "%s\n", &ProgramErrorMessage[0]);
		
		char* aSzoveg = new char[ProgramErrorMessage.size()];
		memcpy( aSzoveg, &ProgramErrorMessage[0], ProgramErrorMessage.size());

		std::cout << "[app.Init()] Sáder Huba panasza: " << aSzoveg << std::endl;

		delete aSzoveg;
	}

	// we can dispose of the vertex and fragment shaders
	glDeleteShader( vs_ID );
	glDeleteShader( fs_ID );

	//
	// other initializations
	//

	// set the projection matrix
	m_matProj = glm::perspective( 45.0f, 640/480.0f, 1.0f, 1000.0f );

	// query the IDs of the shader uniform variables
	m_loc_world = glGetUniformLocation( m_programID, "world");
	m_loc_worldIT = glGetUniformLocation( m_programID, "worldIT");
	m_loc_mvp  = glGetUniformLocation( m_programID, "MVP" );
	m_loc_texture = glGetUniformLocation( m_programID, "texture" );

	// generate the texture
	m_textureID = TextureFromFile("grass.bmp");
	modelTexturaID = TextureFromFile("cat.bmp");

	model = ObjParser::parse("cat.obj");
	model->initBuffers();

	return true;
}

void CMyApp::Clean()
{
	glDeleteBuffers(1, &m_vboID);
	glDeleteBuffers(1, &m_ibID);
	glDeleteVertexArrays(1, &m_vaoID);
	glDeleteTextures(1, &m_textureID);

	glDeleteProgram( m_programID );
}

void CMyApp::Update()
{
	m_eye = glm::vec3( 0 , 15, 15 );

	m_matView = glm::lookAt(m_eye,						// camera position
							glm::vec3( 0,  0,  0),		// look at position
							glm::vec3( 0,  1,  0));		// vector pointing upwards
}

void CMyApp::Render()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glUseProgram( m_programID );
	glUniform1i(m_loc_texture, 0);
	glActiveTexture(GL_TEXTURE0);
	glUniform4fv(glGetUniformLocation(m_programID, "La"), 1, &ambient[0]);

	/*------- TALAJ -------*/
	glm::mat4 matWorld = glm::rotate<float>(SDL_GetTicks()/6000.0*360, 0,1,0) * glm::rotate<float>(SDL_GetTicks() / 6000.0 * 360, 0, 0, 1);
	glm::mat4 matWorldIT = glm::transpose( glm::inverse( matWorld ) );
	glUniformMatrix4fv( m_loc_world, 1, GL_FALSE, &( matWorld[0][0]) ); 
	glUniformMatrix4fv( m_loc_worldIT, 1, GL_FALSE, &( matWorldIT[0][0]) ); 
	glm::mat4 mvp = m_matProj*m_matView*matWorld;
	glUniformMatrix4fv( m_loc_mvp,  1, GL_FALSE, &( mvp[0][0]) );
	glBindTexture(GL_TEXTURE_2D, m_textureID);		
	glBindVertexArray(m_vaoID);
	glDrawArrays(GL_TRIANGLES, 0, 18);
	glBindVertexArray(0);

	/*------- MACSKA -------*/
	matWorld = glm::rotate<float>(SDL_GetTicks() / 6000.0 * 360, 0, 1, 0) * glm::rotate<float>((sin(SDL_GetTicks()/800.0)*0.5-0.5)*30,1,0,0) * glm::translate<float>(0,0,-2)*glm::scale<float>(8, 8, 8);
	matWorldIT = glm::transpose(glm::inverse(matWorld));
	glUniformMatrix4fv(m_loc_world, 1, GL_FALSE, &(matWorld[0][0]));
	glUniformMatrix4fv(m_loc_worldIT, 1, GL_FALSE, &(matWorldIT[0][0]));
	mvp = m_matProj*m_matView*matWorld;
	glUniformMatrix4fv(m_loc_mvp, 1, GL_FALSE, &(mvp[0][0]));
	glBindTexture(GL_TEXTURE_2D, modelTexturaID);

	// model->draw();

	glUseProgram( 0 );
}

void CMyApp::KeyboardDown(SDL_KeyboardEvent& key)
{
	switch (key.keysym.sym)
	{
		case SDLK_UP:
			ambient += 0.2;
			break;
		case SDLK_DOWN:
			ambient -= 0.2;
			break;
	}
}

void CMyApp::KeyboardUp(SDL_KeyboardEvent& key)
{
}

void CMyApp::MouseMove(SDL_MouseMotionEvent& mouse)
{

}

void CMyApp::MouseDown(SDL_MouseButtonEvent& mouse)
{
}

void CMyApp::MouseUp(SDL_MouseButtonEvent& mouse)
{
}

void CMyApp::MouseWheel(SDL_MouseWheelEvent& wheel)
{
}

// a két paraméterbe az új ablakméret szélessége (_w) és magassága (_h) található
void CMyApp::Resize(int _w, int _h)
{
	glViewport(0, 0, _w, _h);

	m_matProj = glm::perspective(  45.0f,		// 90 fokos nyilasszog
									_w/(float)_h,	// ablakmereteknek megfelelo nezeti arany
									0.01f,			// kozeli vagosik
									100.0f);		// tavoli vagosik
}