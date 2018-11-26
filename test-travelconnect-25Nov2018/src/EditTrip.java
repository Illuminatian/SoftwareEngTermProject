import java.util.regex.Pattern;
import java.util.concurrent.TimeUnit;
import org.junit.*;
import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;

public class EditTrip {
  private WebDriver driver;
  private String baseUrl;
  private boolean acceptNextAlert = true;
  private StringBuffer verificationErrors = new StringBuffer();

  @Before
  public void setUp() throws Exception {
	  String path = "C:/Users/BlueBongo/Downloads/chromedriver.exe";
	  System.setProperty("webdriver.chrome.driver", path);
    driver = new ChromeDriver();
    baseUrl = "https://travelconnect.ddns.net/";
    driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
  }

  @Test
  public void testEditTrip() throws Exception {
    driver.get("http://travelconnect.ddns.net/Trip");
    driver.findElement(By.linkText("Login")).click();
    driver.findElement(By.id("Input_Email")).click();
    driver.findElement(By.id("Input_Email")).clear();
    driver.findElement(By.id("Input_Email")).sendKeys("asdf@asdf.edu");
    driver.findElement(By.id("Input_Password")).click();
    driver.findElement(By.id("Input_Password")).clear();
    driver.findElement(By.id("Input_Password")).sendKeys("3ed#ED");
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Password'])[1]/following::button[1]")).click();
    Thread.sleep(3000);
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='A Beautiful Place'])[1]/following::i[6]")).click();
    Thread.sleep(1000);
    driver.findElement(By.id("TravelMode")).click();
    new Select(driver.findElement(By.id("TravelMode"))).selectByVisibleText("Airplane");
    driver.findElement(By.id("TravelMode")).click();
    Thread.sleep(1000);
    driver.findElement(By.id("Cost")).click();
    driver.findElement(By.id("Cost")).clear();
    driver.findElement(By.id("Cost")).sendKeys("1600.00");
    Thread.sleep(1000);
    ((JavascriptExecutor)driver).executeScript("arguments[0].scrollIntoView();", driver.findElement(By.id("Cost")));
    Thread.sleep(1000);
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Upload a custom picture:'])[1]/following::input[2]")).click();
    Thread.sleep(3000);
}

  @After
  public void tearDown() throws Exception {
    driver.quit();
    String verificationErrorString = verificationErrors.toString();
    if (!"".equals(verificationErrorString)) {
      fail(verificationErrorString);
    }
  }

  private boolean isElementPresent(By by) {
    try {
      driver.findElement(by);
      return true;
    } catch (NoSuchElementException e) {
      return false;
    }
  }

  private boolean isAlertPresent() {
    try {
      driver.switchTo().alert();
      return true;
    } catch (NoAlertPresentException e) {
      return false;
    }
  }

  private String closeAlertAndGetItsText() {
    try {
      Alert alert = driver.switchTo().alert();
      String alertText = alert.getText();
      if (acceptNextAlert) {
        alert.accept();
      } else {
        alert.dismiss();
      }
      return alertText;
    } finally {
      acceptNextAlert = true;
    }
  }
}
