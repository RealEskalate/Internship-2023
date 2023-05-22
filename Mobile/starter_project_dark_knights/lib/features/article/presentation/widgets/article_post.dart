// ignore_for_file: file_names

import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/core/utils/images.dart';
import 'package:flutter/material.dart';

class ArticlePost extends StatelessWidget {
  final String description;
  final String imageUrl;

  const ArticlePost(
      {super.key, required this.description, required this.imageUrl});

  @override
  Widget build(BuildContext context) {
    double left = convertPixle(23, "width", context);
    double bottom = convertPixle(23, "height", context);
    double top = convertPixle(17, "height", context);

    double imageSize = convertPixle(219, "width", context);
    double fontSize = convertPixle(16, "width", context);

    return Column(children: [
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
            image: AssetImage(imageUrl),
          ),
        ),
      ),
      Padding(
        padding: EdgeInsets.symmetric(horizontal: left),
        child: Text(
          description,
          style: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.w400,
              color: secondaryTextColor,
              fontFamily: 'Poppins'),
        ),
      )
    ]);
  }
}
