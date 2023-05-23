import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/core/utils/constants/colors.dart';
import 'package:mobile_assessement/features/home/presentation/screen/home_screen.dart';

class CustomButton extends StatelessWidget {
  CustomButton({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 220,
      height: 48,
      decoration: BoxDecoration(
        color: secondaryColor,
        borderRadius: BorderRadius.circular(10),
      ),
      child: TextButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => Home()),
          );
        },
        child: Text(
          'Click me',
          style: TextStyle(
            color: Colors.white,
            fontWeight: FontWeight.bold,
            fontSize: 16,
          ),
        ),
      ),
    );
  }
}
