import 'package:dark_knights/core/utils/converter.dart';
import 'package:flutter/material.dart';

Widget floatingActionButton(context) {
  double fontSize = convertPixle(16, "width", context);
  return FloatingActionButton.extended(
    onPressed: () {},
    label: Text(
      '2.1K',
      style: TextStyle(fontSize: fontSize),
    ),
    icon: const Icon(
      Icons.thumb_up_outlined,
      weight: 1,
    ),
    shape: RoundedRectangleBorder(
      borderRadius: BorderRadius.circular(10),
    ),
  );
}
