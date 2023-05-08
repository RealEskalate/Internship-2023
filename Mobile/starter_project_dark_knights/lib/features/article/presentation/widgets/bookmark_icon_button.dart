import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:flutter/material.dart';

class BookmarkButton extends StatelessWidget {
  const BookmarkButton({super.key});
  @override
  Widget build(BuildContext context) {
    double iconSize = convertPixle(21, "width", context);
    return IconButton(
      iconSize: iconSize,
      icon: const Icon(
        Icons.bookmark_border,
        color: primaryColor,
      ),
      onPressed: () {},
    );
  }
}
