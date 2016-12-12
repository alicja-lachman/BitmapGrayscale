.data
dzielnik dd 3
.code
	;void grayscaleASM(
	;unsigned char* bpmDataScan0 = RCX,
	;unsigned char* rgbValues = RDX,
	;short value =R8W,
	;int imageSizeInBytes = R9D)

grayscaleASM proc 
   mov r10d, 0 ;r10 - licznik edytowanych bajtow
   vzeroall
   	pinsrb xmm3, byte ptr[dzielnik], 0	; 30 do xmm0 aby dodawać do każdego bajtu
	pinsrb xmm3, byte ptr[dzielnik], 1
	pinsrb xmm3, byte ptr[dzielnik], 2
	pinsrb xmm3, byte ptr[dzielnik], 3
   petla:
     cmp r10d, r9d     ;sprawdz ze stopem
     jge KONIEC
   PINSRB xmm0, byte ptr[rdx + r10], 0       ;umieszczenie 4 kolejnych skladowych B w rejestrze xmm0
   PINSRB xmm0, byte ptr[rdx + r10 + 3], 1
   PINSRB xmm0, byte ptr[rdx + r10 + 6], 2
   PINSRB xmm0, byte ptr[rdx + r10 + 9], 3
   
   PINSRB xmm1, byte ptr[rdx + r10 + 1], 0   ;umieszczenie 4 kolejnych skladowych G w rejestrze xmm0
   PINSRB xmm1, byte ptr[rdx + r10 + 4], 1
   PINSRB xmm1, byte ptr[rdx + r10 + 7], 2
   PINSRB xmm1, byte ptr[rdx + r10 + 10], 3
   
   PINSRB xmm2, byte ptr[rdx + r10 + 2], 0   ;umieszczenie 4 kolejnych skladowych B w rejestrze xmm0
   PINSRB xmm2, byte ptr[rdx + r10 + 5], 1
   PINSRB xmm2, byte ptr[rdx + r10 + 8], 2
   PINSRB xmm2, byte ptr[rdx + r10 + 11], 3
   
   PADDD XMM0, XMM1  ;zsumowanie skladowych B i G
   PADDD XMM0, XMM2  ;zsumowanie skladowych B,G i R
   CVTDQ2PS XMM0, XMM0  ;wynik konwertowany do wektora liczb zmiennopozycyjnych pojedynczej precyzji
   
  
   DIVPS XMM0, XMM3
   ;CVTPS2DQ XMM1, XMM0 ;konwersja do liczb calkowitych ?? 
   
   PEXTRW EAX, XMM0, 0
   MOV BYTE PTR [rdx+r10], AL
   MOV BYTE PTR [rdx+r10+4], AL
   MOV BYTE PTR [rdx+r10+8], AL
  
   PEXTRW EAX, XMM0, 1
   MOV BYTE PTR [rdx+r10+1], AL
   MOV BYTE PTR [rdx+r10+5], AL
   MOV BYTE PTR [rdx+r10+9], AL
	
   PEXTRW EAX, XMM0, 2
   MOV BYTE PTR [rdx+r10+2], AL
   MOV BYTE PTR [rdx+r10+6], AL
   MOV BYTE PTR [rdx+r10+10], AL

   PEXTRW EAX, XMM0, 3

   MOV BYTE PTR [rdx+r10+3], AL
   MOV BYTE PTR [rdx+r10+7], AL
   MOV BYTE PTR [rdx+r10+11], AL

	
	add r10, 12
       jmp petla
KONIEC:
	ret
grayscaleASM endp
end