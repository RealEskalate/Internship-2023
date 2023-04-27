// The purpose of this image is the create an image
// with a circular border radius provided as parameter.

import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class ClippedImage extends StatelessWidget {
  final String image;
  final double radius;
  const ClippedImage({super.key, required this.image, required this.radius});

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.circular(radius),
      clipBehavior: Clip.hardEdge,
      child: Image.asset(
        "assets/images/$image.png",
        fit: BoxFit.cover,
      ),
    );
  }
}
