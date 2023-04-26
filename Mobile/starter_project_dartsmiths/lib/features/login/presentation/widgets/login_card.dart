import 'package:flutter/material.dart';

class LoginCard extends StatelessWidget {
  const LoginCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        decoration: const BoxDecoration(
            borderRadius: BorderRadius.only(
              topLeft: Radius.circular(25),
              topRight: Radius.circular(25),
            ),
            color: Colors.white),
        child: Padding(
          padding: const EdgeInsets.fromLTRB(30, 15, 30, 0),
          child: Column(
            children: [
              Column(children: [
                Row(
                  children: [
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: const [
                        Text(
                          "Welcome back",
                          style: TextStyle(
                              fontWeight: FontWeight.w500, fontSize: 20),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        Text(
                          "Sign in with your account",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                      ],
                    ),
                  ],
                ),
                const SizedBox(
                  height: 25,
                ),
                TextFormField(
                  decoration: const InputDecoration(
                      label: Text(
                        "Username",
                      ),
                      hintText: "Jonathandavis@gmail.com"),
                ),
                TextFormField(
                  obscureText: true,
                  decoration: const InputDecoration(
                    label: Text(
                      "Password",
                    ),
                    suffixIcon: Text(
                      "show",
                      style: TextStyle(
                        color: Color(0xFF376AED),
                      ),
                    ),
                  ),
                ),
                const SizedBox(
                  height: 50,
                ),
                SizedBox(
                  height: 60,
                  width: 295,
                  child: ElevatedButton(
                    onPressed: () => {},
                    child: const Text("LOGIN"),
                  ),
                ),
                const SizedBox(
                  height: 10,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: const [
                    Text(
                      "Forgot your password?",
                      style: TextStyle(fontWeight: FontWeight.bold),
                    ),
                    SizedBox(
                      width: 5,
                    ),
                    Text(
                      "Reset here",
                      style: TextStyle(color: Color(0xFF376AED)),
                    )
                  ],
                )
              ]),
            ],
          ),
        ),
      ),
    );
  }
}
