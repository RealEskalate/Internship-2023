// ignore_for_file: file_names

import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/core/utils/images.dart';
import 'package:flutter/material.dart';

class ArticleAuthorProfilePicture extends StatelessWidget {
  final profileImage;
  const ArticleAuthorProfilePicture({super.key, required this.profileImage});

  @override
  Widget build(BuildContext context) {
    double imageSize = convertPixle(38, "width", context);
    return Container(
      width: imageSize,
      height: imageSize,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(10),
        image: DecorationImage(
          fit: BoxFit.cover,
          image: NetworkImage(profileImage),
        ),
      ),
    );
  }
}
