.data
dzielnik dd 3
.code
	;void grayscaleASM(

	;unsigned char* rgbValues = RDX,

	;int imageSizeInBytes = R9D)
 


grayscaleASM proc 
push rbx
push rbp
   mov r10d, 0 ;r10 - licznik edytowanych bajtow
   vzeroall
   mov bl, byte ptr [rdx + r10]
   	pinsrb xmm3, byte ptr[dzielnik], 0	; zaladowanie dzielnika do xmm3
	pinsrb xmm3, byte ptr[dzielnik], 1
	pinsrb xmm3, byte ptr[dzielnik], 2
	pinsrb xmm3, byte ptr[dzielnik], 3
		pinsrb xmm3, byte ptr[dzielnik],4
	pinsrb xmm3, byte ptr[dzielnik], 5
	pinsrb xmm3, byte ptr[dzielnik], 6
	pinsrb xmm3, byte ptr[dzielnik], 7

   petla:
     cmp r10d, r9d     ;sprawdz ze stopem
     jge KONIEC
	 PSUBB xmm0, xmm0
	 PSUBB xmm1, xmm1
   PINSRB xmm0, byte ptr[rdx + r10], 0       ;umieszczenie 4 kolejnych skladowych B w rejestrze xmm0
   PINSRB xmm0, byte ptr[rdx + r10 + 3], 1
   PINSRB xmm0, byte ptr[rdx + r10 + 6], 2
   PINSRB xmm0, byte ptr[rdx + r10 + 9], 3
   PINSRB xmm0, byte ptr[rdx + r10 + 12 ], 4
   PINSRB xmm0, byte ptr[rdx + r10 + 15], 5
   PINSRB xmm0, byte ptr[rdx + r10 + 18], 6
   PINSRB xmm0, byte ptr[rdx + r10 + 21], 7
   
   PINSRB xmm1, byte ptr[rdx + r10 + 1], 0   ;umieszczenie 4 kolejnych skladowych G w rejestrze xmm1
   PINSRB xmm1, byte ptr[rdx + r10 + 4], 1
   PINSRB xmm1, byte ptr[rdx + r10 + 7], 2
   PINSRB xmm1, byte ptr[rdx + r10 + 10], 3
   PINSRB xmm1, byte ptr[rdx + r10 + 13], 4  
   PINSRB xmm1, byte ptr[rdx + r10 + 16], 5
   PINSRB xmm1, byte ptr[rdx + r10 + 19], 6
   PINSRB xmm1, byte ptr[rdx + r10 + 22], 7
      
   PINSRB xmm2, byte ptr[rdx + r10 + 2], 0   ;umieszczenie 4 kolejnych skladowych R w rejestrze xmm2
   PINSRB xmm2, byte ptr[rdx + r10 + 5], 1
   PINSRB xmm2, byte ptr[rdx + r10 + 8], 2
   PINSRB xmm2, byte ptr[rdx + r10 + 11], 3
   PINSRB xmm2, byte ptr[rdx + r10 + 14], 4   
   PINSRB xmm2, byte ptr[rdx + r10 + 17], 5
   PINSRB xmm2, byte ptr[rdx + r10 + 20], 6
   PINSRB xmm2, byte ptr[rdx + r10 + 23], 7
   ;paddusw
   PADDUSB XMM0, XMM1  ;zsumowanie skladowych B i G
   PADDUSB XMM0, XMM2  ;zsumowanie skladowych B,G i R
   CVTDQ2PS XMM0, XMM0  ;wynik konwertowany do wektora liczb zmiennopozycyjnych pojedynczej precyzji
   
  
   DIVPS XMM0, XMM3
 ; CVTPS2DQ XMM0, XMM0 ;konwersja do liczb calkowitych ?? 
   
   PEXTRW EAX, XMM0, 0
  MOV BYTE PTR [rdx+r10], AL
   MOV BYTE PTR [rdx+r10+1], AL
   MOV BYTE PTR [rdx+r10+2], AL
  
   PEXTRW EAX, XMM0, 1
   MOV BYTE PTR [rdx+r10+3], AL
   MOV BYTE PTR [rdx+r10+4], AL
   MOV BYTE PTR [rdx+r10+5], AL
	
   PEXTRW EAX, XMM0, 2
   MOV BYTE PTR [rdx+r10+6], AL
   MOV BYTE PTR [rdx+r10+7], AL
   MOV BYTE PTR [rdx+r10+8], AL

   PEXTRW EAX, XMM0, 3

   MOV BYTE PTR [rdx+r10+9], AL
   MOV BYTE PTR [rdx+r10+10], AL
   MOV BYTE PTR [rdx+r10+11], AL

   PEXTRW EAX, XMM0, 4
   MOV BYTE PTR [rdx+r10+12], AL
   MOV BYTE PTR [rdx+r10+13], AL
   MOV BYTE PTR [rdx+r10+14], AL
  
   PEXTRW EAX, XMM0, 5
   MOV BYTE PTR [rdx+r10+15], AL
   MOV BYTE PTR [rdx+r10+16], AL
   MOV BYTE PTR [rdx+r10+17], AL
	
   PEXTRW EAX, XMM0, 6
   MOV BYTE PTR [rdx+r10+18], AL
   MOV BYTE PTR [rdx+r10+19], AL
   MOV BYTE PTR [rdx+r10+20], AL

   PEXTRW EAX, XMM0, 7

   MOV BYTE PTR [rdx+r10+21], AL
   MOV BYTE PTR [rdx+r10+22], AL
   MOV BYTE PTR [rdx+r10+23], AL

	
	add r10d, 24
       jmp petla
KONIEC:
pop rbp
pop rbx
	ret
grayscaleASM endp
end