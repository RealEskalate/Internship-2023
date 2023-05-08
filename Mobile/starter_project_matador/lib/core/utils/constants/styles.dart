import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';

// TEXT STYLES
const primaryTextStyle = TextStyle(
  fontFamily: "Poppins",
  fontWeight: FontWeight.w600,
  color: defaultTextColor,
);

const searchBarTextStyle = TextStyle(
  fontFamily: "Poppins",
  fontStyle: FontStyle.normal,
  fontSize: 15,
  color: Color.fromRGBO(154, 148, 148, 1),
  height: 1.47,
);

const filterChipsTextStyle = TextStyle(
  fontFamily: "Poppins",
  fontStyle: FontStyle.normal,
  fontSize: 12,
  fontWeight: FontWeight.w500,
  height: 1.5,
);

const cardHeaderTextStyle = TextStyle(
  fontFamily: "Urbanist",
  color: Color.fromRGBO(77, 74, 73, 1),
  fontWeight: FontWeight.w600,
  fontSize: 18,
);

const cardTagTextStyle = TextStyle(
  fontFamily: "Poppins",
  color: Colors.white,
  fontWeight: FontWeight.w600,
  fontSize: 10,
);

const cardAuthorTextStyle = TextStyle(
  fontFamily: "Poppins",
  fontSize: 14,
  fontWeight: FontWeight.w400,
);

const cardDateTextStyle = TextStyle(
    fontFamily: "Poppins",
    fontWeight: FontWeight.w300,
    fontSize: 12,
    color: Color.fromARGB(125, 125, 125, 1));


// SHADOW STYLES

const searchBarShadowStyle = BoxShadow(
    color: Color.fromRGBO(177, 177, 177, 0.25),
    offset: Offset(0, 1),
    blurRadius: 6);

const homePageFirstShadowStyle = BoxShadow(
    color: Color.fromRGBO(0, 0, 0, 0.2),
    offset: Offset(-4, -4),
    blurRadius: 12);

const homePageSecondShadowStyle = BoxShadow(
  color: Color.fromRGBO(0, 0, 0, 0.03),
  offset: Offset(4, 4),
  blurRadius: 8,
);
