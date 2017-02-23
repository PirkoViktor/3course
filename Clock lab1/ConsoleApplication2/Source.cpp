
#include <GL/glut.h>
#include <ctime>
#include "math.h"
#include <time.h>
#include <string.h>
#include <cstdlib>
#include <iostream>
#include <windows.h>
#include <string.h>
int h;
int m;
int s;
int kf=1;
int buttoncenterx = -400;
int buttoncentery = -400;
void handlemouse(int x, int y, int button)
{
	
	int a=glutGet(GLUT_WINDOW_WIDTH)/2;
	
	if (x<a &&  kf!=0)
		kf--;
	if (x>a )
		kf++;

}
void mouseButton(int button, int state, int x, int y)
{
	if ((button == GLUT_LEFT_BUTTON) && (state == GLUT_DOWN))
	{
		handlemouse(x, y, button);
	}

}

void WriteText(int x, int y, char* string)
{
	int len, i;
	glColor3f(1.0, 0, 0);
	glRasterPos2f(x, y);
	len = int(strlen(string));
	for (i = 0; i < len; i++) {
		glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, string[i]);
	}
	glColor3f(0, 0, 1);
}
void display()
{
	long double M_PI = acos(-1.0);
	glClear(GL_COLOR_BUFFER_BIT);
	glBegin(GL_LINES);
	for (int i = 0; i < 12; ++i)
	{
		float x = sin(2 * M_PI / 12 * i);
		float y = cos(2 * M_PI / 12 * i);
		glVertex2f(420 * x, 420 * y);
		glVertex2f(350 * x, 350 * y);
		
		
	}
	glEnd();
	for (int i = 0; i < 12; ++i)
	{
		if (i == 0)i = 12;
		float x = sin(2 * M_PI / 12 * i);
		float y = cos(2 * M_PI / 12 * i);
		int value;
		char string[6] = "";
		_itoa(i, string, 10);
		WriteText(370 * x, 370 * y, string);
		if (i == 12)i = 0;
	}
	glBegin(GL_POLYGON);

	float x = sin(2 * M_PI * (h * 60 + m) / 12 / 60);
	float y = cos(2 * M_PI * (h * 60 + m) / 12 / 60);
	glVertex2f(-10, -10);
	glVertex2f(200 * x, 200 * y);
	glVertex2f(10, 10);
	
	x = sin(2 * M_PI * m / 60);
	y = cos(2 * M_PI * m / 60);
	glVertex2f(-10, -10);
	glVertex2f(350 * x, 350 * y);
	glVertex2f(10, 10);
	
	glEnd();
	
	glBegin(GL_POLYGON);
	glVertex2i(buttoncenterx-50,buttoncentery+50);
	glVertex2i(buttoncenterx+200, buttoncentery+50);
	glVertex2i(buttoncenterx+200, buttoncentery-50);
	glVertex2i(buttoncenterx-50, buttoncentery-50);
	glEnd();
	WriteText(-400, -400, "speed-");
	glBegin(GL_POLYGON);
	glVertex2i(buttoncenterx+650,buttoncentery+50);
	glVertex2i(buttoncenterx+900, buttoncentery+50);
	glVertex2i(buttoncenterx+900, buttoncentery-50);
	glVertex2i(buttoncenterx+650, buttoncentery-50);
	glEnd();
	WriteText(300, -400, "speed+");
	
	glutSwapBuffers();
}

void timer(int = 0)
{
	m+=kf;
	
	display();
	glutTimerFunc(1000, timer, 0);
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(400, 400);
	glutInitWindowPosition(800, 300 - 150 - 20);
	glutCreateWindow("Clock");
	glClearColor(0, 0, 0, 1.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	time_t t = time(0);
	tm *lt = localtime(&t);
	h = lt->tm_hour;
	m = lt->tm_min;
	s = lt->tm_sec;
	glutMouseFunc(mouseButton);
	glOrtho(-500, 500, -500, 500, -500, 500);
	glutDisplayFunc(display);
	
	timer();
	glutMainLoop();
}
