import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../../../../core/utils/images.dart';
import '../../../../core/utils/ui_converter.dart';
import '../widgets/custom_login_text.dart';
import '../widgets/login_card.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: whiteColor,
      body: Column(
        children: [
          Container(
            height: UIConverter.getComponentHeight(context, 54),
            width: UIConverter.getComponentWidth(context, 141),
            margin: EdgeInsets.fromLTRB(
              UIConverter.getComponentWidth(context, 117),
              UIConverter.getComponentHeight(context, 56),
              UIConverter.getComponentWidth(context, 117),
              UIConverter.getComponentHeight(context, 54),
            ),
            child: const Image(
              image: AssetImage(A2SVLogo),
            ),
          ),
          Expanded(
            child: Container(
              decoration: const BoxDecoration(
                color: primaryColor,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(18),
                  topRight: Radius.circular(18),
                ),
              ),
              child: Column(
                children: [
                  Padding(
                    padding: EdgeInsets.fromLTRB(
                        0,
                        UIConverter.getComponentHeight(context, 20),
                        0,
                        UIConverter.getComponentHeight(context, 20)),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: const [
                        CustomLoginText(
                          str: "LOGIN",
                          customColor: whiteColor,
                        ),
                        CustomLoginText(
                          str: "SIGNUP",
                          customColor: trasparentWhiteColor,
                        )
                      ],
                    ),
                  ),
                  const LoginCard()
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
  
}


