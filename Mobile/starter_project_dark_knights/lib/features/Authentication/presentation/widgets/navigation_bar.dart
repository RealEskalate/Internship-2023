import 'package:flutter/material.dart';
import 'package:dark_knights/features/Authentication/presentation/widgets/text_style.dart';

import '../../../../core/utils/colors.dart';

class Navigation extends StatelessWidget {
  const Navigation({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          "LOGIN",
          style: TextStyles.login,
        ),
        //customText(text: "LOGIN", color: whiteColor),
        SizedBox(width: MediaQuery.of(context).size.width * 0.3),
        Text("SIGNUP", style: TextStyles.signUp),
      ],
    );
  }
}
