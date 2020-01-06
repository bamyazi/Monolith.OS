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

name
	: NAME
	;

instruction
	: operation comment?
	;

operation
    : opcode 
    ;

opcode
	: BEGIN_SCOPE 
	| END_SCOPE
	| ASSIGN var argument
	| COMPARE argument argument
	| ADD var argument
	| SUBTRACT var argument
	| MULTIPLY var argument 
	| DIVIDE var argument
	| PUSH argument
	| POP var
	| JUMP label
	| JUMP_EQUAL label
	| JUMP_NOT_EQUAL label
	| JUMP_LESS_THAN label
	| JUMP_GREATER_THAN label
	| CALL 
	| RETURN
	| WRITE var argument
	| READ var argument
	| EXEC
	| LOCK lock
	| RELEASE lock
	| WAIT lock
	| EXIT argument
	;

argument
	: var
	| indexed_var
	| literal
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

var 
	: name
	;

lock
	: name
	;

literal
	: string_literal
	| number_literal
	| list_literal
	;

list_literal
	: '{' list_values '}'
	;

list_values
	: argument (COMMA argument)*
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