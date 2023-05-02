// ignore_for_file: file_names

import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/core/utils/images.dart';
import 'package:flutter/material.dart';

class ArticlePost extends StatelessWidget {
  const ArticlePost({super.key});

  @override
  Widget build(BuildContext context) {
    double left = convertPixle(23, "width", context);
    double bottom = convertPixle(23, "height", context);
    double top = convertPixle(17, "height", context);

    double imageSize = convertPixle(219, "width", context);
    double fontSize = convertPixle(16, "width", context);

    String text =
        "The webpage at https://search.brave.com/search source=web"
        "might be temporarily down or it may have moved permanently to a new web address."
        "The webpage at https://search.brave.com/search source=web"
        "might be temporarily down or it may have moved permanently to a new web address."
        "The webpage at https://search.brave.com/search source=web"
        "might be temporarily down or it may have moved permanently to a new web address."
        "The webpage at https://search.brave.com/search source=web";

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
              fontFamily: 'Poppins'),
        ),
      )
    ]);
  }
}
