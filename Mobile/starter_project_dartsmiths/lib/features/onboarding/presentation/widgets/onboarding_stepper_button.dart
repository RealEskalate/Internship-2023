import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';



class OnboardingStepperButton extends StatelessWidget {
  OnboardingStepperButton({required this.onTap, super.key});
  final void Function()? onTap;
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      child: Container(
          height: MediaQuery.of(context).size.height * 0.08,
          width: MediaQuery.of(context).size.width * 0.22,
          decoration: BoxDecoration(
              color: primaryColor, borderRadius: BorderRadius.circular(12)),
          child: const Icon(
            Icons.arrow_forward,
            color: Colors.white,
          )),
    );
  }
}
