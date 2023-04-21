import 'dart:math';
import 'package:flutter/material.dart';

class BackgroundContainer extends StatefulWidget {
  late double? top;
  late double? right;
  late double? left;
  late double? bottom;
  BackgroundContainer(
      {super.key, this.top, this.right, this.left, this.bottom});

  @override
  State<BackgroundContainer> createState() => _BackgroundContainerState();
}

class _BackgroundContainerState extends State<BackgroundContainer> {
  double pos = 0;
  @override
  void initState() {
    super.initState();
    Future.delayed(const Duration(seconds: 1), () {
      setState(() {
        pos = 200;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return AnimatedPositioned(
      top: widget.top != null ? pos - widget.top! : null,
      left: widget.left != null ? pos - widget.left! : null,
      right: widget.right != null ? pos - widget.right! : null,
      bottom: widget.bottom != null ? pos - widget.bottom! : null,
      duration: const Duration(seconds: 1),
      child: Transform.rotate(
        angle: pi / 4,
        child: AnimatedContainer(
          width: 800,
          height: size.height / 3,
          decoration: BoxDecoration(
              color: const Color.fromARGB(131, 255, 255, 255),
              borderRadius: BorderRadius.circular(100)),
          duration: const Duration(seconds: 1),
        ),
      ),
    );
  }
}
