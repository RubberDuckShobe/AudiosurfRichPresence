// dllmain.cpp : Definiert den Einstiegspunkt für die DLL-Anwendung.
#include "pch.h"
#include <Windows.h>

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

extern "C"
{
	/*
	 i am doing the most inefficient thing imaginable but fuck me it works
	 i suck at c++ btw
	*/
	__declspec(dllexport) void AudiosurfMinimize()
	{
		HWND hwndTargetWin = FindWindow(NULL, TEXT("Audiosurf"));

		//create the command message and data struct
		char* str = (char*)"ascommand minimize";
		COPYDATASTRUCT cds;
		cds.cbData = strlen(str) + 1;
		cds.lpData = (void*)str;

		SendMessage(hwndTargetWin, WM_COPYDATA, 0, (LPARAM)&cds);
	}
	__declspec(dllexport) void AudiosurfMaximize()
	{
		HWND hwndTargetWin = FindWindow(NULL, TEXT("Audiosurf"));

		//create the command message and data struct
		char* str = (char*)"ascommand maximize";
		COPYDATASTRUCT cds;
		cds.cbData = strlen(str) + 1;
		cds.lpData = (void*)str;

		SendMessage(hwndTargetWin, WM_COPYDATA, 0, (LPARAM)&cds);
	}
	__declspec(dllexport) void AudiosurfGoFullscreen()
	{
		HWND hwndTargetWin = FindWindow(NULL, TEXT("Audiosurf"));

		//create the command message and data struct
		char* str = (char*)"ascommand gofullscreen";
		COPYDATASTRUCT cds;
		cds.cbData = strlen(str) + 1;
		cds.lpData = (void*)str;

		SendMessage(hwndTargetWin, WM_COPYDATA, 0, (LPARAM)&cds);
	}
	__declspec(dllexport) void AudiosurfRestoreWindowStyle()
	{
		HWND hwndTargetWin = FindWindow(NULL, TEXT("Audiosurf"));

		//create the command message and data struct
		char* str = (char*)"ascommand restorenormalwindowstyle";
		COPYDATASTRUCT cds;
		cds.cbData = strlen(str) + 1;
		cds.lpData = (void*)str;

		SendMessage(hwndTargetWin, WM_COPYDATA, 0, (LPARAM)&cds);
	}
	__declspec(dllexport) void AudiosurfExit()
	{
		HWND hwndTargetWin = FindWindow(NULL, TEXT("Audiosurf"));

		//create the command message and data struct
		char* str = (char*)"ascommand closeaudiosurf";
		COPYDATASTRUCT cds;
		cds.cbData = strlen(str) + 1;
		cds.lpData = (void*)str;

		SendMessage(hwndTargetWin, WM_COPYDATA, 0, (LPARAM)&cds);
	}
	__declspec(dllexport) void AudiosurfRegisterRPCWindow()
	{
		HWND hwndTargetWin = FindWindow(NULL, TEXT("Audiosurf"));

		//create the command message and data struct
		char* str = (char*)"ascommand registerlistenerwindow AudiosurfRPC";
		COPYDATASTRUCT cds;
		cds.cbData = strlen(str) + 1;
		cds.lpData = (void*)str;

		SendMessage(hwndTargetWin, WM_COPYDATA, 0, (LPARAM)&cds);
	}
}
