COMPILERNAME=cpp
SCANNERTEST=scantest

all: $(COMPILERNAME)
	-

compiler: $(COMPILERNAME)
	-

scanner: lex.yy.cc
	-

parser: parse.cc
	-

clean:
	rm -rf $(COMPILERNAME) $(SCANNERTEST) lex.yy.cc Parserbase.h Parser.ih parse.cc *~

lex.yy.cc: $(COMPILERNAME).l
	flex $(COMPILERNAME).l

parse.cc: $(COMPILERNAME).y
	bisonc++ $(COMPILERNAME).y

$(COMPILERNAME): $(COMPILERNAME).cpp lex.yy.cc parse.cc
	g++ -o$(COMPILERNAME) $(COMPILERNAME).cpp parse.cc lex.yy.cc

$(SCANNERTEST): $(SCANNERTEST).cpp lex.yy.cc
	g++ -o$(SCANNERTEST) $(SCANNERTEST).cpp lex.yy.cc
