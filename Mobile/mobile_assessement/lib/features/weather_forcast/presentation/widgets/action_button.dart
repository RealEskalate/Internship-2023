import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../screens/weather.dart';

class ActionButton extends StatelessWidget {
  const ActionButton({super.key, required this.height, required this.child});

  final double height;
  final Widget child;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: height,
        child: ElevatedButton(
          style: ElevatedButton.styleFrom(
            backgroundColor: Color(0xFFFFBA25),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(height * 0.3),
            ),
          ),
          onPressed: () {
            Navigator.push(
                context, MaterialPageRoute(builder: (context) => Weather()));
          },
          child: child,
        ));
  }
}
