grammar MonoLang;

prog
	: (line? EOL) +
	;

line
	: comment
	| label
	| instruction
	;

comment
	: COMMENT
	;

label
	: name ':'
	;

address
	: name
	| NUMBER
	;

port
	: '$' name
	;

name
	: NAME
	;

instruction
	: operation comment?
	;

operation
    : begin_scope 
	| end_scope
	| assign var expression
	| compare expression expression
	| add var expression
	| subtract var expression
	| multiply var expression
	| divide var expression
	| push expression
	| pop var
	| jump address
	| jump_equal address
	| jump_not_equal address
	| jump_less_than address
	| jump_greater_than address
	| call address
	| return
	| write port expression
	| read port var
	| exit expression
    ;

begin_scope : BEGIN_SCOPE ;
end_scope : END_SCOPE ;
assign : ASSIGN ;
compare : COMPARE;
add : ADD;
subtract : SUBTRACT;
multiply : MULTIPLY;
divide : DIVIDE;
push : PUSH;
pop : POP;
jump : JUMP;
jump_equal : JUMP_EQUAL;
jump_not_equal : JUMP_NOT_EQUAL;
jump_less_than : JUMP_LESS_THAN;
jump_greater_than : JUMP_GREATER_THAN;
call : CALL;
return : RETURN;
write : WRITE;
read : READ;
exit : EXIT;

expression
	: var_pointer
	| var
	| literal
	;

var_pointer
	: var'->'
	;

var 
	: named_var
	| indexed_var
	;

named_var
	: name
	;

indexed_var
	: name '[' (index | range) ']'
	;

index
	: NUMBER
	;

range
	: range_start '..' range_end
	;

range_start : NUMBER ;
range_end : NUMBER ;

literal
	: string_literal
	| number_literal
	| list_literal
	;

list_literal
	: '{' list_values '}'
	;

list_values
	: expression (COMMA expression)*
	;

string_literal
	: STRING
	;

number_literal
	: NUMBER
	;

BEGIN_SCOPE : 'begin_scope'|'BEGIN_SCOPE' ;
END_SCOPE : 'end_scope'|'END_SCOPE' ;
ASSIGN : 'assign'|'ASSIGN' ;
COMPARE : 'compare'|'COMPARE' ;
ADD : 'add'|'ADD' ;
SUBTRACT : 'subtract'|'SUBTRACT';
MULTIPLY : 'multiply'|'MULTIPLY';
DIVIDE : 'divide'|'DIVIDE' ;
PUSH : 'push'|'PUSH' ;
POP : 'pop'|'POP' ;
JUMP : 'jump'|'JUMP';
JUMP_EQUAL : 'jump_equal'|'JUMP_EQUAL' ;
JUMP_NOT_EQUAL : 'jump_not_equal'|'JUMP_NOT_EQUAL' ;
JUMP_LESS_THAN : 'jump_less_than'|'JUMP_LESS_THAN' ;
JUMP_GREATER_THAN : 'jump_greater_than'|'JUMP_GREATER_THAN' ;
CALL : 'call'|'CALL';
RETURN : 'return'|'RETURN' ;
WRITE : 'write'|'WRITE' ;
READ : 'read'|'READ' ;
EXEC : 'exec'|'EXEC' ;
LOCK : 'lock'|'LOCK' ;
RELEASE : 'release'|'RELEASE';
WAIT : 'wait'|'WAIT' ;
EXIT : 'exit'|'EXIT' ;

COMMENT
   : ';' ~ [\r\n]*    
   ;

NAME
   : [a-zA-Z] [a-zA-Z0-9."]*
   ;

STRING
   : '"' ~ ["]* '"'
   ;

NUMBER
   : '-'? [0-9] +
   ;

COMMA
	: ','
	;

OPENBRACE 
	: '{'
	;

CLOSEBRACE
	: '}'
	;

EOL
   : [\r\n]+ 
   ;

WS
   : [ \t] -> skip
   ;