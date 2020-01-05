start:
	MOV AX, 0
loop:
	ADD AX, 10
	JMP end:
	ADD AX, 10
end:
	EXIT AX

