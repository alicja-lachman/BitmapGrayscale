.data
dzielnik dd 3
.code
	;void grayscaleASM(
	;unsigned char* rgbValues = RCX,
	;int imageSizeInBytes = RDX)
 
grayscaleASM proc 

push rbx
push rbp
   mov r10, 0     ;r10 - licznik edytowanych bajtow
   
   vzeroall ;wyzerowanie rejestrow xmmn
   movzx eax, byte ptr[dzielnik]
   	pinsrd xmm3, eax, 0	; zaladowanie dzielnika do xmm3
	pinsrd xmm3, eax, 1
	pinsrd xmm3,eax, 2
	pinsrd xmm3, eax, 3


   petla:
     cmp r10, RDX     ;sprawdz ze stopem
     jge KONIEC

	 PSUBB xmm0, xmm0				    ;wyzerowanie xmm0
	 PSUBB xmm1, xmm1					;wyzerowanie xmm1


    movzx eax, byte ptr[rcx +r10]
   PINSRD xmm0, eax, 0       ;umieszczenie 4 kolejnych skladowych B w rejestrze xmm0
     movzx eax, byte ptr[rcx +r10+3]
   PINSRD xmm0, eax, 1
     movzx eax, byte ptr[rcx +r10 + 6]
   PINSRD xmm0, eax, 2
     movzx eax, byte ptr[rcx +r10 +9]
   PINSRD xmm0, eax, 3
   ;CVTDQ2PS xmm0, xmm0                       ;konwersja do liczb zmiennopozycyjnych

       movzx eax, byte ptr[rcx +r10+1]
   PINSRD xmm1, eax, 0   ;umieszczenie 4 kolejnych skladowych G w rejestrze xmm0
       movzx eax, byte ptr[rcx +r10 +4]
   PINSRD xmm1, eax, 1
       movzx eax, byte ptr[rcx +r10+7]
   PINSRD xmm1, eax, 2
       movzx eax, byte ptr[rcx +r10+10]
   PINSRD xmm1, eax, 3
   
          movzx eax, byte ptr[rcx +r10+2]
   PINSRD xmm2, eax, 0   ;umieszczenie 4 kolejnych skladowych R w rejestrze xmm0
          movzx eax, byte ptr[rcx +r10+5]
   PINSRD xmm2, eax, 1
          movzx eax, byte ptr[rcx +r10+8]
   PINSRD xmm2, eax, 2
          movzx eax, byte ptr[rcx +r10+11]
   PINSRD xmm2, eax, 3
  ; CVTDQ2PS xmm2, xmm2                        ;konwersja do liczb zmiennopozycyjnych

 
   PADDD XMM0, XMM1  ;zsumowanie skladowych B i G  z nasyceniem
   PADDD XMM0, XMM2  ;zsumowanie skladowych B,G i R

   
  
   DIVPS XMM0, XMM3      ;podzielenie sumy znajdujacej sie w XMM0 przez 3 z XMM3
 CVTPS2DQ XMM0, XMM0  ;Convert four packed single-precision floating-point values from xmm2/m128 

   
   PEXTRW EAX, XMM0, 0              
   MOV BYTE PTR [rcx+r10], AL
   MOV BYTE PTR [rcx+r10+1], AL
   MOV BYTE PTR [rcx+r10+2], AL
  
   PEXTRW EAX, XMM0, 1
   MOV BYTE PTR [rcx+r10+3], AL
   MOV BYTE PTR [rcx+r10+4], AL
   MOV BYTE PTR [rcx+r10+5], AL
	
   PEXTRW EAX, XMM0, 2
   MOV BYTE PTR [rcx+r10+6], AL
   MOV BYTE PTR [rcx+r10+7], AL
   MOV BYTE PTR [rcx+r10+8], AL

   PEXTRW EAX, XMM0, 3

   MOV BYTE PTR [rcx+r10+9], AL
   MOV BYTE PTR [rcx+r10+10], AL
   MOV BYTE PTR [rcx+r10+11], AL

  

   add r10, 12
   jmp petla

KONIEC:
pop rbp
pop rbx
ret
grayscaleASM endp
end
