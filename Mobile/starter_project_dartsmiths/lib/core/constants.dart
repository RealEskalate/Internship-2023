import 'package:flutter/material.dart';


class BlogFontConstant {
  static TextTheme postArticleTheme = const TextTheme(
    // title fonts
    displayLarge: TextStyle(
      fontSize: 24,
      // fontFamily: 'Poppins',
      color: Color(0XFF0D253C)
    ),

    // place holder font
    bodyLarge:  TextStyle(
      fontSize: 19,
      // fontFamily: 'Poppins',
      color: Color(0XFF979EA5)
    ),

    // button font
    bodyMedium: TextStyle(
      fontSize: 17,
      // fontFamily: 'Poppins',
      color: Color(0XFFFFFFFF)
    ),

    // small watermarked words font
    bodySmall: TextStyle(
      fontSize: 12,
      fontWeight: FontWeight.w500,
      // fontFamily: 'Poppins',
      color: Color(0XFF979EA5)
    )

    );
 
  
}

class BlogColorConstant {
  static  Color headerTitle = const  Color(0XFF0D253C);
  static  Color backIconColor = const Color(0XFF878585);
  static  Color backIconBgColor = const Color(0XFFEAEBF0);
  static  Color paceHolderColor  = const Color(0XFF979EA5);
  static  Color borderLineColor = const Color(0X7B8BB242);
  static  Color buttonTextColor = const Color(0XFFFFFFFF);
  static  Color buttonBgColor = const Color(0XFF376AED);
  static  Color contentBgColor = const Color(0XFFD7DDEB);
  static  Color addIcondColor = const Color(0XFF376AED);
  static  Color chipsBgColor = const Color(0XFF376AED);

}

