start:
	MOV &0, 100
	MOV AX, 10
	ADD BX, 0
	ADD AX, [BX]
end:
	EXIT AX

