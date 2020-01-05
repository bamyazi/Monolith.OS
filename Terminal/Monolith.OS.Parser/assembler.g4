grammar assembler;

prog
	: (line? EOL) +
	;

line
	: comment
	| label
	| instruction
	;

instruction
	: label? operation comment?
	;

operation
    : opcode arguments?
    ;

opcode
	: MOV
    | ADD
    | CMP
    | JMP | JEQ | JNE | JLT | JGT
    | PUSH | POP |
    | CALL | RET |
    | INPUT | OUTPUT |
    | NOP
    | EXIT
	;

arguments
   : argument 
   | argument ',' argument
   ;

argument
   : register
   | indirectregister
   | number
   | address
   | label
   ;

address
    : '&' number
    ;

indirectregister
    : '[' register ']'
    ;

register
    : REGISTER
    ;

prefix
   : '#'
   ;

string
   : STRING
   ;

name
   : NAME
   ;

number
   : NUMBER
   ;

label
	: name ':'
	;

comment
    : COMMENT
    ;

REGISTER
    : 'ax'|'AX'
    | 'bx'|'BX'
    | 'cx'|'CX'
    | 'dx'|'DX'
    | 'ex'|'EX'

    | 'fx'|'FX'
    | 'gx'|'GX'
    | 'hx'|'HX'
    | 'ix'|'IX'
    | 'jx'|'JX'
    ;

MOV : 'mov'|'MOV' ;
ADD	: 'add'|'ADD' ;
SUB	: 'sub'|'SUB' ;
CMP : 'cmp'|'CMP' ;
JMP : 'jmp'|'JMP' ;
JEQ : 'jeq'|'JEQ' ;
JNE : 'jne'|'JNE' ;
JLT : 'jlt'|'JLT' ;
JGT : 'jgt'|'JGT' ;
NOP : 'nop'|'NOP' ;
PUSH : 'push'|'PUSH' ;
POP : 'pop'|'POP' ;
CALL : 'call'|'CALL' ;
RET : 'ret'|'RET' ;
INPUT : 'input'|'INPUT' ;
OUTPUT : 'output'|'OUTPUT' ;
EXIT : 'exit'|'EXIT' ;

COMMENT
   : ';' ~ [\r\n]* 
   ;

NAME
   : [a-zA-Z] [a-zA-Z0-9."]*
   ;

NUMBER
   : '-'? [0-9] +
   ;

STRING
   : '"' ~ ["]* '"'
   ;

EOL
   : [\r\n]+ 
   ;
WS
   : [ \t] -> skip
   ;