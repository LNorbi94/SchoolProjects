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
#include <QtWidgets/QMessageBox>

class PolishCalculator : public QWidget
{
    Q_OBJECT

public:
    explicit
    PolishCalculator(QWidget* parent = nullptr) : QWidget(parent)
    {
        setFixedSize(150, 400);
        table = new QTableWidget;
        queryEdit = new QLineEdit;
        polishEdit = new QLineEdit;
        solution = new QLineEdit;

        solution->setEnabled(0);

        QPushButton* calc = new QPushButton;
        calc->setText("Calculate");

        table->setColumnCount(2);
        table->setRowCount(0);
        QStringList header;
        header << "Variable" << "Value";
        table->setHorizontalHeaderLabels(header);
        //table->setItem(0, 0, new QTableWidgetItem("X"));
        //table->setItem(0, 1, new QTableWidgetItem("40"));
        table->setColumnWidth(0, 49);
        table->setColumnWidth(1, 37);
        table->setGeometry(10, 10, 110, 50);

        solutionLayout = new QHBoxLayout;
        solutionLayout->addWidget( new QLabel("="));
        solutionLayout->addWidget(solution);

        mainLayout = new QVBoxLayout;
        mainLayout->addWidget(queryEdit);
        mainLayout->addWidget(calc);
        mainLayout->addLayout(solutionLayout);
        mainLayout->addWidget( new QLabel("PolishForm:") );
        mainLayout->addWidget(polishEdit);
        mainLayout->addWidget(table);
        setLayout(mainLayout);

        connect( calc, SIGNAL(clicked())
                 , this, SLOT(calculate()) );
    }
    ~PolishCalculator()
    {
        delete table;
    }

private slots:

    void calculate()
    {
        QString input = queryEdit->text();
        if( isCorrect(input) )
        {
            QString polish = toPolish(input);

            QStringList inputList = polish.split(", ");
            long long sol = 0;
            int numOne = 0;
            int numTwo = 0;
            bool snd = false;
            for(int i = 0; i < inputList.size(); ++i)
            {
                QString j = inputList[i];
                if(j == "+")
                {
                    sol = numOne + numTwo;
                }
                else if(j == "-")
                {
                    sol = (numOne - numTwo);
                }
                else if(j == "^")
                {
                    sol = numOne;
                    for(int i = 1; i < numTwo; ++i)
                    {
                        sol *= numOne;
                    }
                }
                else
                {
                    if(!snd)
                    {
                        numOne = j.toInt();
                        snd = !snd;
                        sol = numOne;
                    }
                    else
                    {
                        numOne = sol;
                        numTwo = j.toInt();
                    }
                }
            }
            solution->setText( QString::number(sol) );
            polishEdit->setText(polish);
        }
        else
        {
            QMessageBox::warning(this, "Error!", "The input is incorrect.");
        }
    }

private:
    bool isCorrect(QString input) const
    {
        std::queue<QChar> stack;
        for (int i = 0; i < input.size(); ++i)
        {
            const QChar ch = input[i];
            if (ch == '(')
            {
                stack.push(ch);
            }
            else if (ch == ')')
            {
                if (stack.size() == 0)
                    return false;
                stack.pop();
            }
        }
        return stack.size() == 0;
    }

    QString toPolish(QString input)
    {
        auto stack = std::deque<char>();
        QString ret = "";
        for (int i = 0; i < input.size(); ++i)
        {
            char j = input.at(i).toLatin1();
            if (j != ' ')
            {
                if (j == '(')
                {
                    stack.push_back(j);
                }
                else if (j == ')')
                {
                    while (stack.back() != '(')
                    {
                        ret += stack.back();
                        ret += ", ";
                        stack.pop_back();
                    }
                    stack.pop_back();
                }
                else if (j == '*' || j == '/' || j == '^')
                {
                    stack.push_back(j);
                }
                else if (j == '+' || j == '-')
                {
                    while (!stack.empty() && (stack.back() == '*'
                        || stack.back() == '/'
                        || stack.back() == '+' || stack.back() == '-'))
                    {
                        ret += stack.back();
                        ret += ", ";
                        stack.pop_back();
                    }
                    stack.push_back(j);
                }
                else
                {
                    while(isdigit(j) && i != input.size())
                    {
                        j = input.at(i).toLatin1();
                        if( isdigit(j) )
                        {
                            ret += j;
                            ++i;
                        }
                    }
                    ret += ", ";
                }
            }
        }
        bool nFirst = false;
        for (auto& i : stack)
        {
            if (nFirst)
                ret += ", ";
            else
                nFirst = 1 | nFirst;
            ret += i;
        }
        return ret;
    }

    QTableWidget* table;
    QLineEdit* queryEdit;
    QLineEdit* solution;
    QLineEdit* polishEdit;

    QHBoxLayout* solutionLayout;
    QVBoxLayout* mainLayout;
};
