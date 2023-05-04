import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class PublishButton extends StatelessWidget {
  const PublishButton({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 300,
      height: 100,
      padding: const EdgeInsets.fromLTRB(130, 30, 130, 30),
      child: GestureDetector(
        onTap: () {},
        child: Container(
          width: 10,
          height: 50,
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(50),
            color: primaryColor,
          ),
          child: const Center(
              child: Text(
            'Publish',
            style: TextStyle(
              fontFamily: 'Poppins',
              color: whiteColor,
              fontSize: 15,
              fontWeight: FontWeight.w500,
            ),
          )),
        ),
      ),
    );
  }
}
