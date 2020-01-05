start:
	MOV AX, 0
	MOV BX, 0
loop:
	ADD AX, 1
	ADD BX, 10
	CMP AX, 10
	JLT loop:
	NOP
	NOP
	NOP
end:
	EXIT AX

