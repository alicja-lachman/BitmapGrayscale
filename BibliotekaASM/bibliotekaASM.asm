.data
.code
	;void grayscaleASM(
	;unsigned char* bpmDataScan0 = RCX,
	;unsigned char* rgbValues = RDX,
	;short value =R8W,
	;int imageSizeInBytes = R9D)

grayscaleASM proc 
	mov r10, 0
	cmp r8w, 0
	jl SubtractBrightness
	
	mov r11w, 0ffffh
	
MainLoopAdd:
	mov al, byte ptr [rcx + r10]
	add al, r8b
	cmovc ax, r11w
	mov byte ptr [rdx + r10], al
	inc r10
	dec r9d
	jnz MainLoopAdd
	ret
SubtractBrightness:
		mov r11w, 0
		neg r8w
MainLoopSubtract:
	mov al, byte ptr [rcx + r10]
	sub al, r8b
	cmovc ax, r11w
	mov byte ptr [rdx + r10], al
	inc r10
	dec r9d
	jnz MainLoopSubtract
	ret
grayscaleASM endp
end