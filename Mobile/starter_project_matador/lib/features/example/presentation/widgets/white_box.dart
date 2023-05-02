import 'package:flutter/material.dart';

// This box is made inorder the UI fit the figma design
class Box extends StatelessWidget {
  const Box({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: (28 / 812) * MediaQuery.of(context).size.height,
      width: double.infinity,
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.only(
          topLeft:
              Radius.circular((28 / 812) * MediaQuery.of(context).size.height),
          topRight:
              Radius.circular((28 / 812) * MediaQuery.of(context).size.height),
        ),
      ),
    );
  }
}
