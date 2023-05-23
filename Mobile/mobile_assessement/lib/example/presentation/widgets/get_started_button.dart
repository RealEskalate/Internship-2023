import 'package:flutter/material.dart';
import 'package:mobile_assessement/core/utils/constants/global_variables.dart';

class GetStartedButton extends StatelessWidget {
  const GetStartedButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 50,
      width: 150,
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(
          backgroundColor: primaryButtonColor,
        ),
        onPressed: () {
          // Action to perform when the button is pressed
        },
        child: Text("Get Started"),
      ),
    );
  }
}
