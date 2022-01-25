
fn main() {
    println!("{}",add_f64(2.0,8.0));
}

/// add two f64 numbers
#[no_mangle]
pub extern fn add_f64(num1: f64, num2: f64) -> f64 {
    num1 + num2
}

/// substract two two f64 numbers
/// floating point numbers are weird so we use this rounding trick
#[no_mangle]
pub extern fn sub_f64(num1: f64, num2: f64) -> f64 {
    ((num1 - num2)*1e5_f64).round()/1e5_f64
}

// multiply two f64 numbers
#[no_mangle]
pub extern fn multi_f64(num1: f64, num2: f64) -> f64 {
    num1 * num2
}

/// divide two f64 numbers
#[no_mangle]
pub extern fn div_f64(num1: f64, num2: f64) -> f64 {
    if num2 != 0_f64 {
        num1 / num2
    }
    else {
        panic!("bad number");
    }
}

/// right now only full numbers (aka no digits)
#[no_mangle]
pub extern fn pow_f64(base: f64,  rase: f64) -> f64 {
    let mut res = 1_f64;
    if rase == 0_f64 {
        return 1_f64;
    }
    else if rase < 0_f64 {
        let base = rase * (-1_f64);
        for _i in 1..=base as u8{
            res = res * base;
        }
        return 1_f64/res
    } 
    else {    
        for _i in 1..=rase as u8{
        res = res * base;
        }
        return res
    }

}

/// take power of 2
pub extern fn pow2_f64(base: f64) -> f64 {
    return base * base
}


#[cfg(test)]
pub mod tests{
    
    #[test]
    fn add_test1() {
        assert_eq!(crate::add_f64(2.0,8.0), 10.0);
    }

    #[test]
    fn add_test2(){
        assert_eq!(crate::add_f64(5.2, 3.1), 8.3)
    } 

    #[test]
    fn sub_test1(){
        assert_eq!(crate::sub_f64(10.0, 5.31), 4.69_f64)
    }

    #[test]
    fn sub_test2(){
        assert_eq!(crate::sub_f64(10.0, -5.31), 15.31_f64)
    }

    #[test]
    fn multi_test1(){
        assert_eq!(crate::multi_f64(15.0, 3.0), 45.0_f64)
    }

    #[test]
    fn multi_test2(){
        assert_eq!(crate::multi_f64(15.491, 3.13), 48.48683_f64)
    }

    #[test]
    #[should_panic]
    fn div_test1(){
        assert_eq!(crate::div_f64(10_f64, 0_f64), std::f64::INFINITY)
    }

    #[test]
    fn div_test2(){
        assert_eq!(crate::div_f64(15.30, 0.64), 23.90625_f64)
    }

    #[test]
    fn pow_test1(){
        assert_eq!(crate::pow_f64(2.0,2.0), 4.0)
    }

    #[test]
    fn pow_test2(){
        assert_eq!(crate::pow_f64(2.0,-2.0), 0.25)
    }

    #[test]
    fn pow2_test1(){
        assert_eq!(crate::pow2_f64(2.0), 4.0)
    }

    #[test]
    fn pow2_test2(){
        assert_eq!(crate::pow2_f64(-2.0), 4.0)
    }
}

