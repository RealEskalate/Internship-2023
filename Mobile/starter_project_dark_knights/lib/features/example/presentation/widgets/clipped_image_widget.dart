import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class ClippedImage extends StatelessWidget {
  final String image;
  const ClippedImage({super.key, required this.image});

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.circular(30.0),
      clipBehavior: Clip.hardEdge,
      child: Image.asset(
        "assets/images/$image.png",
        fit: BoxFit.cover,
      ),
    );
  }
}
