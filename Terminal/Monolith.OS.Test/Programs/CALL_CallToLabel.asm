start:
	MOV AX, 0
	MOV BX, 0
loop:
	CALL increment:
	CMP AX, 10
	JNE loop:
end:
	EXIT AX
increment:
	ADD AX, 1
	ADD BX, 10
	RET


