 #pragma once
 // based from : https://stackoverflow.com/questions/5966594/how-can-i-use-pragma-message-so-that-the-message-points-to-the-filelineno
 #define Stringize( L )     #L 
 #define MakeString( M, L ) M(L)
 #define $Line MakeString( Stringize, __LINE__ )
 #define LOG(TYPE) __FILE__ "(" $Line ") : ["#TYPE"] "