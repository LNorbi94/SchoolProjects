#pragma once

#include <QWidget>
#include <QtWidgets/QTableWidget>
#include <queue>
#include <deque>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QFileDialog>
#include <QtWidgets/QMessageBox>
#include <QTextStream>

class PolishCalculator : public QWidget
{
	Q_OBJECT

	enum Operation
	{
		NONE
		, ADD
		, SUBSTRACT
		, MULTIPLY
		, DIVIDE
	};

public:
	explicit
	PolishCalculator(QWidget* parent = nullptr) : QWidget(parent)
	{
		setFixedSize(150, 400);

		table = new QTableWidget;
		table->setColumnCount(2);
		table->setRowCount(10);
		QStringList header;
		header << "Variable" << "Value";
		table->setHorizontalHeaderLabels(header);
		table->setItem(0, 0, new QTableWidgetItem("X"));
		table->setItem(0, 1, new QTableWidgetItem("40"));
		table->setColumnWidth(0, 47);
		table->setColumnWidth(1, 47);
		table->setGeometry(10, 10, 110, 100);

		mainLayout = new QVBoxLayout;
		mainLayout->addWidget(table);
		setLayout(mainLayout);
	}
	~PolishCalculator()
	{
		delete table;
	}

private slots:

	void calculate()
	{
	}

private:
	bool isCorrect(QString input) const
	{
		auto stack = std::queue<char>();
		for (auto i = 0; i < input.size(); ++i)
		{
			if (input[i] == '(')
			{
				stack.push('(');
			}
			if (input[i] == ')')
			{
				if (stack.size() == 0)
					return false;
				stack.pop();
			}
			if (input[i] == '*' || input[i] == '/' || input[i] == '-' || input[i] == '+')
			{
				if (input[i - 1] == '*' || input[i - 1] == '/' || input[i - 1] == '-' || input[i - 1] == '+')
					return false;
			}
		}
		if (stack.size() > 0)
			return false;
		return true;
	}

	QString toPolish(QString input)
	{
		if (!isCorrect(input))
			return "Input text format is not valid.";
		auto stack = std::deque<char>();
		QString ret = "";
		for (auto& i : input)
		{
			if (!(i == ' '))
			{
				if (i == '(')
				{
					stack.push_back(i.toLatin1());
				}
				else if (i == ')')
				{
					while (stack.back() != '(')
					{
						ret += stack.back();
						ret += ", ";
						stack.pop_back();
					}
					stack.pop_back();
				}
				else if (i == '*' || i == '/')
				{
					stack.push_back(i.toLatin1());
				}
				else if (i == '+' || i == '-')
				{
					while (!stack.empty() && (stack.back() == '*'
						|| stack.back() == '/'
						|| stack.back() == '+' || stack.back() == '-'))
					{
						ret += stack.back();
						ret += ", ";
						stack.pop_back();
					}
					stack.push_back(i.toLatin1());
				}
				else
				{
					ret += i;
					ret += ", ";
				}
			}
		}
		for (auto& i : stack)
		{
			ret += i;
			ret += ", ";
		}
		return ret;
	}

	QTableWidget* table;

	QHBoxLayout* upperLayout;
	QVBoxLayout* mainLayout;
};