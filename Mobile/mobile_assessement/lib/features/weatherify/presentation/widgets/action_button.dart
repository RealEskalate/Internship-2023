import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class ActionButton extends StatelessWidget {

  final VoidCallback onTap;
  const ActionButton(
      {super.key, required this.height, required this.child, required this.onTap});

  final double height;
  final Widget child;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: height,
        child: ElevatedButton(
          style: ElevatedButton.styleFrom(
            backgroundColor: primaryColor,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(height * 0.18),
            ),
          ),
          onPressed: onTap,
          child: child,
        ));
  }
}
