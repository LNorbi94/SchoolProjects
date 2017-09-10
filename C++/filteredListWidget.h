#pragma once

#include <QtWidgets/QLineEdit>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QFileDialog>
#include <QtWidgets/QMessageBox>
#include <QTextStream>

class FilteredListWidget : public QWidget
{
	Q_OBJECT

public:
	explicit
	FilteredListWidget(QWidget* parent = nullptr) : QWidget(parent)
	{
		setFixedSize(300, 400);
		setWindowTitle("Filtering a list");

		resultList = new QListWidget;
		queryLabel = new QLabel("Filter:");
		queryLabel->setGeometry(2, 2, 50, 20);
		queryEdit = new QLineEdit;

		loadButton = new QPushButton("Open File");

		upperLayout = new QHBoxLayout;
		upperLayout->addWidget(queryLabel);
		upperLayout->addWidget(queryEdit);

		mainLayout = new QVBoxLayout;
		mainLayout->addLayout(upperLayout);
		mainLayout->addWidget(resultList);
		mainLayout->addWidget(loadButton);

		setLayout(mainLayout);

		connect( queryEdit, SIGNAL(textChanged(QString)), this, SLOT(filterList()) );
		connect( loadButton, SIGNAL(clicked()), this, SLOT(loadFile()) );
	}
	~FilteredListWidget()
	{
		delete resultList;
		delete queryLabel;
		delete queryEdit;
		delete loadButton;
		delete upperLayout;
		delete mainLayout;
	}

private slots:
	void filterList()
	{
		QString filterText = queryEdit->text();
		resultList->clear();
		resultList->addItems(filterText.isNull() ? lines : lines.filter(filterText));
	}

	void loadFile()
	{
		QString filename = QFileDialog::getOpenFileName(this, "Open File", "", "Normal Textfiles (*.txt)");
		if( !filename.isNull() )
		{
			loadItems(filename);
		}
	}

private:
	void loadItems(QString filename)
	{
		QFile file(filename);
		if(file.open(QFile::ReadOnly))
		{
			lines.clear();
			resultList->clear();
			queryEdit->clear();

			QTextStream stream(&file);
			QString line = stream.readLine();
			while(!stream.atEnd())
			{
				lines << line;
				line = stream.readLine();
			}

			resultList->addItems(lines);
		}
		else
		{
			QMessageBox::warning(this, "Error!", "I can't find / read the following file: " + filename);
		}
	}

	QStringList lines;
	QListWidget* resultList;
	QLabel* queryLabel;
	QLineEdit* queryEdit;
	QPushButton* loadButton;

	QHBoxLayout* upperLayout;
	QVBoxLayout* mainLayout;
};
