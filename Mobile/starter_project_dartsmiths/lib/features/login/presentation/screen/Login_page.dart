import 'package:dartsmiths/features/login/presentation/widgets/login_card.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class Login extends StatelessWidget {
  const Login({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: whiteColor,
      body: Column(
        children: [
          Container(
            margin: const EdgeInsets.fromLTRB(117, 56, 117, 54),
            child: const Image(
              image: AssetImage('assets/images/a2sv_logo.jpg'),
            ),
          ),
          const SizedBox(
            height: 10,
          ),
          Expanded(
            child: Container(
              decoration: const BoxDecoration(
                color: primaryColor,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(25),
                  topRight: Radius.circular(25),
                ),
              ),
              child: Column(
                children: [
                  const SizedBox(
                    height: 25,
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: const [
                      Text(
                        "LOGIN",
                        style: TextStyle(color: primaryColor),
                      ),
                      Text(
                        "SIGN UP",
                      ),
                    ],
                  ),
                  const SizedBox(
                    height: 25,
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
