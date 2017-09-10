global main
extern be_elojeles_egesz
extern ki_elojeles_egesz
section .bss
    X resd 1
    Y resd 1
section .text
main:
    call be_elojeles_egesz
    mov [X], eax
    call be_elojeles_egesz
    mov [Y], eax
    mov eax, [Y]
    push eax
    mov eax, [X]
    push eax
    mov eax, 2
    pop ebx
    mul ebx
    pop ebx
    add eax, ebx
    push eax
    call ki_elojeles_egesz
    add esp, 4
    ret