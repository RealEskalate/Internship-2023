import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/core/utils/images.dart';
import 'package:flutter/material.dart';

Container profilePicture(context) {
  double imageSize = convertPixle(38, "width", context);
  return Container(
    width: imageSize,
    height: imageSize,
    decoration: BoxDecoration(
      borderRadius: BorderRadius.circular(10),
      image: const DecorationImage(
        fit: BoxFit.cover,
        image: AssetImage(profileImage),
      ),
    ),
  );
}
