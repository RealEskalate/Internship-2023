import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:flutter/material.dart';
import 'package:dark_knights/core/utils/images.dart';

Widget post(context) {
  double left = convertPixle(23, "width", context);
  double bottom = convertPixle(36, "height", context);
  double top = convertPixle(17, "height", context);

  double imageSize = convertPixle(219, "width", context);
  double fontSize = convertPixle(16, "width", context);
  double fontHeight = convertPixle(24, "width", context);

  String text =
      "That marked a turnaround from last year, when the social network reported a decline in users for the first time."
      "The drop wiped billions from the firm's market value.\n \n"
      "Since executives disclosed the fall in February, the firm's share price has nearly halved."
      "But shares jumped 19% in after-hours trade on Wednesday.\n\n"
      "That marked a turnaround from last year, when the social network reported a decline in users for the first time."
      "The drop wiped billions from the firm's market value.\n\n"
      "Since executives disclosed the fall in February, the firm's share price has nearly halved."
      "But shares jumped 19% in after-hours trade on Wednesday.\n\n"
      "That marked a turnaround from last year, when the social network reported a decline in users for the first time."
      "The drop wiped billions from the firm's market value."
      "Since executives disclosed the fall in February, the firm's share price has nearly halved."
      "But shares jumped 19% in after-hours trade on Wednesday.";
  return Column(
    children: [
      Padding(
        padding: EdgeInsets.only(bottom: bottom, top: top),
        child: ClipRRect(
          borderRadius: const BorderRadius.only(
            topLeft: Radius.circular(20),
            topRight: Radius.circular(20),
          ),
          child: Image(
            fit: BoxFit.cover,
            height: imageSize,
            width: double.infinity,
            image: const AssetImage(postImage),
          ),
        ),
      ),
      Padding(
        padding: EdgeInsets.symmetric(horizontal: left),
        child: Text(
          text,
          style: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.w400,
            color: secondaryTextColor,
            fontFamily: 'Poppins',
          ),
        ),
      ),
    ],
  );
}
