#include <string>
#include <iostream>
#include <fstream>
#include <vector>

#include <GL/glew.h>

// Az http://www.opengl-tutorial.org/ oldal alapj�n.

GLuint loadShader (GLenum _shaderType, const char* _fileName)
{
	GLuint loadedShader = glCreateShader(_shaderType);

	if (!loadedShader)
	{
		std::cerr << "Hiba a " << _fileName << " shader inicializasakor (glCreateShader)!" << std::endl;
		return 0;
	}

	std::string shaderCode = "";
	std::ifstream shaderStream(_fileName);

	if (!shaderStream.is_open())
	{
		std::cerr << "Hiba a " << _fileName << " shader fajl betoltesekor!" << std::endl;
		return 0;
	}

	std::string line = "";
	while (std::getline(shaderStream, line))
	{
		shaderCode += line + "\n";
	}

	const char* sourcePointer = shaderCode.c_str();
	glShaderSource(loadedShader, 1, &sourcePointer, nullptr);

	glCompileShader(loadedShader);

	GLint result = GL_FALSE;
	int infoLogLength;

	glGetShaderiv(loadedShader, GL_COMPILE_STATUS, &result);
	glGetShaderiv(loadedShader, GL_INFO_LOG_LENGTH, &infoLogLength);

	if (GL_FALSE == result)
	{
		std::vector<char> VertexShaderErrorMessage(infoLogLength);
		glGetShaderInfoLog(loadedShader, infoLogLength, nullptr, &VertexShaderErrorMessage[0]);
		std::cerr << &VertexShaderErrorMessage[0] << std::endl;
	}

	return loadedShader;
}

GLuint loadProgramVSGSFS(const char* _fileNameVS, const char* _fileNameGS, const char* _fileNameFS)
{
	GLuint vs_ID = loadShader(GL_VERTEX_SHADER, _fileNameVS);
	GLuint gs_ID = loadShader(GL_GEOMETRY_SHADER, _fileNameGS);
	GLuint fs_ID = loadShader(GL_FRAGMENT_SHADER, _fileNameFS);

	if (vs_ID == 0 || gs_ID == 0 || fs_ID == 0)
	{
		return 0;
	}

	GLuint program_ID = glCreateProgram();

	std::cout << "Linking program" << std::endl;
	glAttachShader(program_ID, vs_ID);
	glAttachShader(program_ID, gs_ID);
	glAttachShader(program_ID, fs_ID);

	glLinkProgram(program_ID);

	GLint infoLogLength = 0, result = 0;

	glGetProgramiv(program_ID, GL_LINK_STATUS, &result);
	glGetProgramiv(program_ID, GL_INFO_LOG_LENGTH, &infoLogLength);
	if (GL_FALSE == result)
	{
		std::vector<char> ProgramErrorMessage(infoLogLength);
		glGetProgramInfoLog(program_ID, infoLogLength, nullptr, &ProgramErrorMessage[0]);
		std::cerr << &ProgramErrorMessage[0] << std::endl;
	}

	glDeleteShader(vs_ID);
	glDeleteShader(gs_ID);
	glDeleteShader(fs_ID);

	return program_ID;
}