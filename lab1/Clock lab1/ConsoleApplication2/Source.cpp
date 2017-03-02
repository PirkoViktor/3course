#define _CRT_SECURE_NO_WARNINGS

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
	glClear(GL_COLOR_BUFFER_BIT);
	
	
	glBegin(GL_POLYGON);
	glVertex2i(buttoncenterx-50,buttoncentery+50);
	glVertex2i(buttoncenterx+200, buttoncentery+50);
	glVertex2i(buttoncenterx+200, buttoncentery-50);
	glVertex2i(buttoncenterx-50, buttoncentery-50);
	glEnd();
	WriteText(buttoncenterx - 50, buttoncenterx - 50, "speed-");
	glBegin(GL_POLYGON);
	glVertex2i(buttoncenterx+650,buttoncentery+50);
	glVertex2i(buttoncenterx+900, buttoncentery+50);
	glVertex2i(buttoncenterx+900, buttoncentery-50);
	glVertex2i(buttoncenterx+650, buttoncentery-50);
	glEnd();
	WriteText(buttoncenterx + 650, buttoncentery + 50, "speed+");
	
	glutSwapBuffers();
}

void timer(int = 0)
{
	buttoncenterx +=(-2+rand()%6);
	buttoncentery +=( -2+rand() % 6);
	display();
	glutTimerFunc(10, timer, 0);
}

int main(int argc, char **argv)
{
	int a = 0;
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
