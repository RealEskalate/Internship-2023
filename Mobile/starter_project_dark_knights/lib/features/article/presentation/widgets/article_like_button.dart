import '../../../../core/utils/colors.dart';
import '../../../../core/utils/converter.dart';
import 'package:flutter/material.dart';

class ArticleLikeButton extends StatelessWidget {
  final int likeCount;
  const ArticleLikeButton({super.key, required this.likeCount});

  @override
  Widget build(BuildContext context) {
    double iconSize = convertPixle(21, "width", context);
    double fontSize = convertPixle(16, 'width', context);
    return FloatingActionButton.extended(
      onPressed: () {},
      label: Text(
        '$likeCount',
        style: TextStyle(fontSize: fontSize),
      ),
      icon: const Icon(Icons.thumb_up_outlined, weight: 1),
      shape: RoundedRectangleBorder( borderRadius: BorderRadius.circular(10),)
    );
  }
}
