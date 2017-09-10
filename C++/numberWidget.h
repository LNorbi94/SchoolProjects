#pragma once

#include <QtWidgets/QApplication>
#include <QtWidgets/QSlider>
#include <QtWidgets/QLCDNumber>

class NumberWidget : public QWidget
{
public:
	NumberWidget(QWidget* parent = nullptr) : QWidget(parent)
	{
		setWindowTitle("Number Display");
		setFixedSize(130, 80);
		_slider = new QSlider(this);
		_lcdNumber = new QLCDNumber(this);
		_slider->setGeometry(10, 10, 100, 10);
		_slider->setOrientation(Qt::Horizontal);
		_slider->setMinimum(0);
		_slider->setMaximum(1000);
		_slider->setValue(0);
		_lcdNumber->setGeometry(10, 30, 100, 20);

		connect( _slider, SIGNAL(valueChanged(int))
						 , _lcdNumber, SLOT(display(int)) );
	}
	~NumberWidget()
	{
		delete _slider;
		delete _lcdNumber;
	}
	
private:
	QSlider* _slider;
	QLCDNumber* _lcdNumber;
};
