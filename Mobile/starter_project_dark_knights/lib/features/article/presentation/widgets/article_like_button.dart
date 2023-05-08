import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:flutter/material.dart';

class ArticleLikeButton extends StatelessWidget {
  const ArticleLikeButton({super.key});

  @override
  Widget build(BuildContext context) {
    double iconSize = convertPixle(21, "width", context);
    double fontSize = convertPixle(16, 'width', context);
    return FloatingActionButton.extended(
      onPressed: () {},
      label: Text(
        '2.1k',
        style: TextStyle(fontSize: fontSize),
      ),
      icon: const Icon(Icons.thumb_up_outlined, weight: 1),
      shape: RoundedRectangleBorder( borderRadius: BorderRadius.circular(10),)
    );
  }
}
