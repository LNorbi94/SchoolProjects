global main
extern be_egesz
extern ki_egesz
section .bss
    X   resd  2
section .text
main:
    call be_egesz
    mov [X], eax
    mul dword [X]
    mov [X + 1], eax
    push dword [X + 1]
    call ki_egesz
    add esp, 4
    ret