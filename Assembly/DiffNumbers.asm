global main ; nasm -f elf DiffNumbers.asm && gcc -m32 DiffNumbers.o io.c && ./a.out
extern be_egesz
extern ki_egesz
section .bss ; Block Started by Symbol
    X   resd  1
    Y   resd  1
    Z   resd  1
section .text
main:
    call be_egesz
    mov [X], eax
    call be_egesz
    mov [Y], eax
    call be_egesz
    mov [Z], eax
    cmp eax, [X]
    je equal
    cmp eax, [Y]
    je equal
    mov eax, [X]
    cmp eax, [Y]
    je equal
    push 1
    jmp finish
equal:
    push 0
finish:
    call ki_egesz
    add esp, 4
    ret